using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class OutfitRepositorio : IOutfitRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public OutfitRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<Outfit?> ObtenerPorIdAsync(int id)
        {
            return await _context.Outfits.FindAsync(id);
        }

        public async Task<IEnumerable<Outfit>> ObtenerTodosAsync()
        {
            return await _context.Outfits.ToListAsync();
        }

        public async Task AgregarAsync(Outfit outfit)
        {
            await _context.Outfits.AddAsync(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Outfit outfit)
        {
            _context.Outfits.Update(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var outfit = await _context.Outfits.FindAsync(id);
            if (outfit != null)
            {
                _context.Outfits.Remove(outfit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
