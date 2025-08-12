using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;

namespace ModaQuisqueya.Application.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepositorio _tiendaRepositorio;

        public TiendaService(ITiendaRepositorio tiendaRepositorio)
        {
            _tiendaRepositorio = tiendaRepositorio;
        }

        public async Task<TiendaDto?> ObtenerPorIdAsync(int id)
        {
            var tienda = await _tiendaRepositorio.ObtenerPorIdAsync(id);
            if (tienda == null) return null;

            return new TiendaDto
            {
                Id = tienda.Id,
                Nombre = tienda.Nombre,
                Direccion = tienda.Direccion,
                Telefono = tienda.Telefono,
                SitioWeb = tienda.SitioWeb
            };
        }

        public async Task<IEnumerable<TiendaDto>> ObtenerTodasAsync()
        {
            var tiendas = await _tiendaRepositorio.ObtenerTodasAsync();

            return tiendas.Select(t => new TiendaDto
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Direccion = t.Direccion,
                Telefono = t.Telefono,
                SitioWeb = t.SitioWeb
            });
        }

        public async Task AgregarAsync(TiendaDto dto)
        {
            var tienda = new Tienda
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                SitioWeb = dto.SitioWeb
            };

            await _tiendaRepositorio.AgregarAsync(tienda);
        }

        public async Task ActualizarAsync(TiendaDto dto)
        {
            var tienda = new Tienda
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                SitioWeb = dto.SitioWeb
            };

            await _tiendaRepositorio.ActualizarAsync(tienda);
        }

        public async Task EliminarAsync(int id)
        {
            await _tiendaRepositorio.EliminarAsync(id);
        }
    }
}
