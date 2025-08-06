using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class TendenciaRepositorio : ITendenciaRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public TendenciaRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<Tendencia?> ObtenerPorIdAsync(int id)
        {
            return await _context.Tendencias.FindAsync(id);
        }

        public async Task<IEnumerable<Tendencia>> ObtenerTodasAsync()
        {
            return await _context.Tendencias.ToListAsync();
        }

        public async Task AgregarAsync(Tendencia tendencia)
        {
            await _context.Tendencias.AddAsync(tendencia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Tendencia tendencia)
        {
            _context.Tendencias.Update(tendencia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var tendencia = await _context.Tendencias.FindAsync(id);
            if (tendencia != null)
            {
                _context.Tendencias.Remove(tendencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}
