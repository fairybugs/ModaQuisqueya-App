using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class DiseñadorRepositorio : IDiseñadorRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public DiseñadorRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<Diseñador?> ObtenerPorIdAsync(int id)
        {
            return await _context.Diseñadores.FindAsync(id);
        }

        public async Task<IEnumerable<Diseñador>> ObtenerTodosAsync()
        {
            return await _context.Diseñadores.ToListAsync();
        }

        public async Task AgregarAsync(Diseñador diseñador)
        {
            await _context.Diseñadores.AddAsync(diseñador);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Diseñador diseñador)
        {
            _context.Diseñadores.Update(diseñador);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var diseñador = await _context.Diseñadores.FindAsync(id);
            if (diseñador != null)
            {
                _context.Diseñadores.Remove(diseñador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
