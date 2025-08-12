
const API_BASE_URL = 'https://localhost:7136/api';

// Estado global
let currentEntity = 'diseñadores';
let isEditing = false;

// Inicializar cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', function() {
    setupEventListeners();
    loadEntityData('diseñadores');
});

// Event Listeners
function setupEventListeners() {
    // Formularios
    document.getElementById('diseñador-form').addEventListener('submit', (e) => handleFormSubmit(e, 'diseñadores'));
    document.getElementById('outfit-form').addEventListener('submit', (e) => handleFormSubmit(e, 'outfits'));
    document.getElementById('tendencia-form').addEventListener('submit', (e) => handleFormSubmit(e, 'tendencias'));
    document.getElementById('tienda-form').addEventListener('submit', (e) => handleFormSubmit(e, 'tiendas'));
}

// Cambiar tabs
function showTab(event, entity) {
    // Remover active de todos los tabs y botones
    document.querySelectorAll('.tab-content').forEach(tab => tab.classList.remove('active'));
    document.querySelectorAll('.tab-btn').forEach(btn => btn.classList.remove('active'));
    
    // Activar tab y botón seleccionado
    document.getElementById(entity + '-tab').classList.add('active');
    event.target.classList.add('active');
    
    // Actualizar estado y cargar datos
    currentEntity = entity;
    hideForm(entity);
    loadEntityData(entity);
}

// Mostrar formulario
function showForm(entity) {
    const form = document.getElementById(entity + '-form');
    form.classList.remove('hidden');
    // Solo limpiar y setear isEditing = false si NO estamos editando
    if (!isEditing) {
        clearForm(entity);
    }
}

// Ocultar formulario
function hideForm(entity) {
    const form = document.getElementById(entity + '-form');
    form.classList.add('hidden');
    clearForm(entity);
    isEditing = false;
}

// Limpiar formulario
function clearForm(entity) {
    const formId = entity.endsWith('s') ? entity.slice(0, -1) + '-form' : entity + '-form';
    const form = document.getElementById(formId);
    if (form) {
        form.reset();
        // Limpiar campo ID oculto
        const hiddenInput = form.querySelector('input[type="hidden"]');
        if (hiddenInput) hiddenInput.value = '';
    }
    // Resetear el estado de edición solo cuando limpiamos manualmente
    isEditing = false;
}

// Mostrar/ocultar loading
function showLoading() {
    document.getElementById('loading').classList.remove('hidden');
}

function hideLoading() {
    document.getElementById('loading').classList.add('hidden');
}

// Mostrar mensaje de error
function showError(message) {
    const errorDiv = document.getElementById('error-message');
    errorDiv.querySelector('.error-text').textContent = message;
    errorDiv.classList.remove('hidden');
    setTimeout(() => hideError(), 5000);
}

function hideError() {
    document.getElementById('error-message').classList.add('hidden');
}

// Mostrar mensaje de éxito
function showSuccess(message) {
    const successDiv = document.getElementById('success-message');
    successDiv.querySelector('.success-text').textContent = message;
    successDiv.classList.remove('hidden');
    setTimeout(() => hideSuccess(), 3000);
}

function hideSuccess() {
    document.getElementById('success-message').classList.add('hidden');
}

// Hacer petición a la API
async function makeApiRequest(endpoint, options = {}) {
    try {
        showLoading();
        
        const response = await fetch(`${API_BASE_URL}${endpoint}`, {
            headers: {
                'Content-Type': 'application/json',
                ...options.headers
            },
            ...options
        });

        if (!response.ok) {
            throw new Error(`Error ${response.status}: ${response.statusText}`);
        }

        // Si es DELETE o PUT sin contenido, devolver true
        if (response.status === 204) {
            return true;
        }

        // Si hay contenido JSON, devolverlo
        const contentType = response.headers.get('content-type');
        if (contentType && contentType.includes('application/json')) {
            return await response.json();
        }

        return true;
    } catch (error) {
        showError(`Error de conexión: ${error.message}`);
        throw error;
    } finally {
        hideLoading();
    }
}

// Cargar datos de una entidad
async function loadEntityData(entity) {
    try {
        const endpoints = {
            'diseñadores': '/Diseñadores',
            'outfits': '/Outfits',
            'tendencias': '/Tendencias',
            'tiendas': '/Tiendas'
        };

        const data = await makeApiRequest(endpoints[entity]);
        renderTable(entity, data || []);
    } catch (error) {
        console.error('Error al cargar datos:', error);
        renderTable(entity, []);
    }
}

// Renderizar tabla
function renderTable(entity, data) {
    const tbody = document.getElementById(entity + '-tbody');
    
    if (!data || data.length === 0) {
        tbody.innerHTML = `
            <tr>
                <td colspan="6" class="empty-state">
                    <h3>No hay datos disponibles</h3>
                    <p>Agrega el primer registro usando el botón de arriba.</p>
                </td>
            </tr>
        `;
        return;
    }

    let html = '';
    data.forEach(item => {
        html += generateTableRow(entity, item);
    });
    
    tbody.innerHTML = html;
}

// Generar fila de tabla según entidad
function generateTableRow(entity, item) {
    switch(entity) {
        case 'diseñadores':
            return `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nombre}</td>
                    <td>${item.especialidad}</td>
                    <td>${truncateText(item.biografia, 100)}</td>
                    <td><img src="${item.fotoUrl}" alt="${item.nombre}" class="image-preview" onerror="this.style.display='none'"></td>
                    <td>
                        <button class="btn-edit" onclick="editItem('diseñadores', ${item.id})">Editar</button>
                        <button class="btn-delete" onclick="deleteItem('diseñadores', ${item.id})">Eliminar</button>
                    </td>
                </tr>
            `;
        case 'outfits':
            return `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nombre}</td>
                    <td>${truncateText(item.descripcion, 100)}</td>
                    <td><img src="${item.imagenUrl}" alt="${item.nombre}" class="image-preview" onerror="this.style.display='none'"></td>
                    <td>
                        <button class="btn-edit" onclick="editItem('outfits', ${item.id})">Editar</button>
                        <button class="btn-delete" onclick="deleteItem('outfits', ${item.id})">Eliminar</button>
                    </td>
                </tr>
            `;
        case 'tendencias':
            return `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nombre}</td>
                    <td>${truncateText(item.descripcion, 100)}</td>
                    <td><span class="badge">${item.temporada}</span></td>
                    <td>
                        <button class="btn-edit" onclick="editItem('tendencias', ${item.id})">Editar</button>
                        <button class="btn-delete" onclick="deleteItem('tendencias', ${item.id})">Eliminar</button>
                    </td>
                </tr>
            `;
        case 'tiendas':
            return `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nombre}</td>
                    <td>${item.direccion}</td>
                    <td>${item.telefono}</td>
                    <td><a href="${item.sitioWeb}" target="_blank" class="link">${truncateText(item.sitioWeb, 30)}</a></td>
                    <td>
                        <button class="btn-edit" onclick="editItem('tiendas', ${item.id})">Editar</button>
                        <button class="btn-delete" onclick="deleteItem('tiendas', ${item.id})">Eliminar</button>
                    </td>
                </tr>
            `;
        default:
            return '';
    }
}

// Truncar texto
function truncateText(text, maxLength) {
    if (!text) return '';
    return text.length > maxLength ? text.substring(0, maxLength) + '...' : text;
}

// Manejar envío de formularios
async function handleFormSubmit(event, entity) {
    event.preventDefault();
    
    const formData = collectFormData(entity);
    const endpoint = getEndpoint(entity);
    
    try {
        if (isEditing) {
            await makeApiRequest(`${endpoint}/${formData.id}`, {
                method: 'PUT',
                body: JSON.stringify(formData)
            });
            showSuccess(`${getEntityName(entity)} actualizado correctamente`);
        } else {
            await makeApiRequest(endpoint, {
                method: 'POST',
                body: JSON.stringify(formData)
            });
            showSuccess(`${getEntityName(entity)} creado correctamente`);
        }
        
        hideForm(entity);
        loadEntityData(entity);
    } catch (error) {
        console.error('Error en formulario:', error);
    }
}

// Recopilar datos del formulario
function collectFormData(entity) {
    const singular = entity.slice(0, -1); // Remove 's' from plural
    
    switch(entity) {
        case 'diseñadores':
            return {
                id: parseInt(document.getElementById('diseñador-id').value) || 0,
                nombre: document.getElementById('diseñador-nombre').value,
                especialidad: document.getElementById('diseñador-especialidad').value,
                biografia: document.getElementById('diseñador-biografia').value,
                fotoUrl: document.getElementById('diseñador-foto').value
            };
        case 'outfits':
            return {
                id: parseInt(document.getElementById('outfit-id').value) || 0,
                nombre: document.getElementById('outfit-nombre').value,
                descripcion: document.getElementById('outfit-descripcion').value,
                imagenUrl: document.getElementById('outfit-imagen').value
            };
        case 'tendencias':
            return {
                id: parseInt(document.getElementById('tendencia-id').value) || 0,
                nombre: document.getElementById('tendencia-nombre').value,
                descripcion: document.getElementById('tendencia-descripcion').value,
                temporada: document.getElementById('tendencia-temporada').value
            };
        case 'tiendas':
            return {
                id: parseInt(document.getElementById('tienda-id').value) || 0,
                nombre: document.getElementById('tienda-nombre').value,
                direccion: document.getElementById('tienda-direccion').value,
                telefono: document.getElementById('tienda-telefono').value,
                sitioWeb: document.getElementById('tienda-sitio').value
            };
    }
}

// Endpoint de la API
function getEndpoint(entity) {
    const endpoints = {
        'diseñadores': '/Diseñadores',
        'outfits': '/Outfits',
        'tendencias': '/Tendencias',
        'tiendas': '/Tiendas'
    };
    return endpoints[entity];
}

// Obtener nombre de entidad para mensajes
function getEntityName(entity) {
    const names = {
        'diseñadores': 'Diseñador',
        'outfits': 'Outfit',
        'tendencias': 'Tendencia',
        'tiendas': 'Tienda'
    };
    return names[entity];
}

// Editar item
async function editItem(entity, id) {
    try {
        const endpoint = getEndpoint(entity);
        const item = await makeApiRequest(`${endpoint}/${id}`);
        
        if (item) {
            isEditing = true;
            showForm(entity);
            populateForm(entity, item);
        }
    } catch (error) {
        console.error('Error al cargar item para editar:', error);
    }
}

// Llenar formulario para editar
function populateForm(entity, item) {
    switch(entity) {
        case 'diseñadores':
            document.getElementById('diseñador-id').value = item.id;
            document.getElementById('diseñador-nombre').value = item.nombre;
            document.getElementById('diseñador-especialidad').value = item.especialidad;
            document.getElementById('diseñador-biografia').value = item.biografia;
            document.getElementById('diseñador-foto').value = item.fotoUrl;
            break;
        case 'outfits':
            document.getElementById('outfit-id').value = item.id;
            document.getElementById('outfit-nombre').value = item.nombre;
            document.getElementById('outfit-descripcion').value = item.descripcion;
            document.getElementById('outfit-imagen').value = item.imagenUrl;
            break;
        case 'tendencias':
            document.getElementById('tendencia-id').value = item.id;
            document.getElementById('tendencia-nombre').value = item.nombre;
            document.getElementById('tendencia-descripcion').value = item.descripcion;
            document.getElementById('tendencia-temporada').value = item.temporada;
            break;
        case 'tiendas':
            document.getElementById('tienda-id').value = item.id;
            document.getElementById('tienda-nombre').value = item.nombre;
            document.getElementById('tienda-direccion').value = item.direccion;
            document.getElementById('tienda-telefono').value = item.telefono;
            document.getElementById('tienda-sitio').value = item.sitioWeb;
            break;
    }
}

// Eliminar item
async function deleteItem(entity, id) {
    if (!confirm('¿Estás seguro de que quieres eliminar este registro?')) {
        return;
    }

    try {
        const endpoint = getEndpoint(entity);
        await makeApiRequest(`${endpoint}/${id}`, { method: 'DELETE' });
        
        showSuccess(`${getEntityName(entity)} eliminado correctamente`);
        loadEntityData(entity);
    } catch (error) {
        console.error('Error al eliminar:', error);
    }
}