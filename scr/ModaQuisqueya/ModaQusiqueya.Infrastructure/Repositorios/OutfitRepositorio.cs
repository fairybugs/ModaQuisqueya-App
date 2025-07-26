using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Api.Data;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<OutfitModel>> ObtenerTodosAsync()
        {
            var outfits = await _context.Outfits.ToListAsync();
            return outfits.Select(o => new OutfitModel
            {
                Id = o.Id,
                Nombre = o.Nombre,
                Descripción = o.Descripción,
                ImagenUrl = o.ImagenUrl
            }).ToList();
        }

        public async Task<OutfitModel?> ObtenerPorIdAsync(int id)
        {
            var outfit = await _context.Outfits.FindAsync(id);
            if (outfit == null) return null;

            return new OutfitModel
            {
                Id = outfit.Id,
                Nombre = outfit.Nombre,
                Descripción = outfit.Descripción,
                ImagenUrl = outfit.ImagenUrl
            };
        }

        public async Task CrearAsync(OutfitModel outfitModel)
        {
            var outfit = new Outfit
            {
                Nombre = outfitModel.Nombre,
                Descripción = outfitModel.Descripción,
                ImagenUrl = outfitModel.ImagenUrl
            };

            _context.Outfits.Add(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(OutfitModel outfitModel)
        {
            var outfit = await _context.Outfits.FindAsync(outfitModel.Id);
            if (outfit != null)
            {
                outfit.Nombre = outfitModel.Nombre;
                outfit.Descripción = outfitModel.Descripción;
                outfit.ImagenUrl = outfitModel.ImagenUrl;

                _context.Outfits.Update(outfit);
                await _context.SaveChangesAsync();
            }
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
