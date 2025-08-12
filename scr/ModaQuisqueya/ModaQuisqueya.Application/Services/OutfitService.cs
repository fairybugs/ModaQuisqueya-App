using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModaQuisqueya.Application.Services
{
    public class OutfitService : IOutfitService
    {
        private readonly IOutfitRepositorio _outfitRepositorio;

        public OutfitService(IOutfitRepositorio outfitRepositorio)
        {
            _outfitRepositorio = outfitRepositorio;
        }

        public async Task<OutfitDto?> ObtenerPorIdAsync(int id)
        {
            var outfit = await _outfitRepositorio.ObtenerPorIdAsync(id);
            if (outfit == null) return null;

            return new OutfitDto
            {
                Id = outfit.Id,
                Nombre = outfit.Nombre,
                Descripcion = outfit.Descripcion,
                ImagenUrl = outfit.ImagenUrl
            };
        }

        public async Task<IEnumerable<OutfitDto>> ObtenerTodosAsync()
        {
            var outfits = await _outfitRepositorio.ObtenerTodosAsync();
            return outfits.Select(o => new OutfitDto
            {
                Id = o.Id,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion,
                ImagenUrl = o.ImagenUrl
            });
        }

        public async Task AgregarAsync(OutfitDto dto)
        {
            var outfit = new Outfit
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                ImagenUrl = dto.ImagenUrl
            };

            await _outfitRepositorio.AgregarAsync(outfit);
        }

        public async Task ActualizarAsync(OutfitDto dto)
        {
            var outfit = new Outfit
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                ImagenUrl = dto.ImagenUrl
            };

            await _outfitRepositorio.ActualizarAsync(outfit);
        }

        public async Task EliminarAsync(int id)
        {
            await _outfitRepositorio.EliminarAsync(id);
        }
    }
}
