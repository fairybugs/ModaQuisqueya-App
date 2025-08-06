using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class TiendaRepositorio : ITiendaRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public TiendaRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<Tienda?> ObtenerPorIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        public async Task<IEnumerable<Tienda>> ObtenerTodasAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task AgregarAsync(Tienda tienda)
        {
            await _context.Tiendas.AddAsync(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Tienda tienda)
        {
            _context.Tiendas.Update(tienda);
            await _context.SaveChangesAsync();
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
