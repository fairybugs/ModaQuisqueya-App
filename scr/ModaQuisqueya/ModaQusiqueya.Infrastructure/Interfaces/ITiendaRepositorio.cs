using ModaQuisqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface ITiendaRepositorio
    {
        Task<List<TiendaModel>> ObtenerTodosAsync();
        Task<TiendaModel?> ObtenerPorIdAsync(int id);
        Task CrearAsync(TiendaModel tienda);
        Task ActualizarAsync(TiendaModel tienda);
        Task EliminarAsync(int id);
    }
}

