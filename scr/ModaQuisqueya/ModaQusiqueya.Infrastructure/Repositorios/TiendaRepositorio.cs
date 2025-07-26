using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Api.Data;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class TiendaRepositorio : ITiendaRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public TiendaRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<List<TiendaModel>> ObtenerTodosAsync()
        {
            var tiendas = await _context.Tiendas.ToListAsync();
            return tiendas.Select(t => new TiendaModel
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Dirección = t.Direccion,
                Telefono = t.Telefono,
                SitioWeb = t.SitioWeb
            }).ToList();
        }

        public async Task<TiendaModel?> ObtenerPorIdAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda == null) return null;

            return new TiendaModel
            {
                Id = tienda.Id,
                Nombre = tienda.Nombre,
                Dirección = tienda.Direccion,
                Telefono = tienda.Telefono,
                SitioWeb = tienda.SitioWeb
            };
        }

        public async Task CrearAsync(TiendaModel tiendaModel)
        {
            var tienda = new Tienda
            {
                Nombre = tiendaModel.Nombre,
                Direccion = tiendaModel.Dirección,
                Telefono = tiendaModel.Telefono,
                SitioWeb = tiendaModel.SitioWeb
            };

            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(TiendaModel tiendaModel)
        {
            var tienda = await _context.Tiendas.FindAsync(tiendaModel.Id);
            if (tienda != null)
            {
                tienda.Nombre = tiendaModel.Nombre;
                tienda.Direccion = tiendaModel.Dirección;
                tienda.Telefono = tiendaModel.Telefono;
                tienda.SitioWeb = tiendaModel.SitioWeb;

                _context.Tiendas.Update(tienda);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                await _context.SaveChangesAsync();
            }
        }
    }
}

