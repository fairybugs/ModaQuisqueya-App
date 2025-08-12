
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModaQuisqueya.Application.Services
{
    public class TendenciaService : ITendenciaService
    {
        private readonly ITendenciaRepositorio _tendenciaRepositorio;

        public TendenciaService(ITendenciaRepositorio tendenciaRepositorio)
        {
            _tendenciaRepositorio = tendenciaRepositorio;
        }

        public async Task<TendenciaDto?> ObtenerPorIdAsync(int id)
        {
            var tendencia = await _tendenciaRepositorio.ObtenerPorIdAsync(id);
            if (tendencia == null) return null;

            return new TendenciaDto
            {
                Id = tendencia.Id,
                Nombre = tendencia.Nombre,
                Descripcion = tendencia.Descripcion,
                Temporada = tendencia.Temporada
            };
        }

        public async Task<IEnumerable<TendenciaDto>> ObtenerTodasAsync()
        {
            var tendencias = await _tendenciaRepositorio.ObtenerTodasAsync();
            return tendencias.Select(t => new TendenciaDto
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Temporada = t.Temporada
            });
        }

        public async Task AgregarAsync(TendenciaDto dto)
        {
            var tendencia = new Tendencia
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Temporada = dto.Temporada
            };

            await _tendenciaRepositorio.AgregarAsync(tendencia);
        }

        public async Task ActualizarAsync(TendenciaDto dto)
        {
            var tendencia = new Tendencia
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Temporada = dto.Temporada
            };

            await _tendenciaRepositorio.ActualizarAsync(tendencia);
        }

        public async Task EliminarAsync(int id)
        {
            await _tendenciaRepositorio.EliminarAsync(id);
        }
    }
}
