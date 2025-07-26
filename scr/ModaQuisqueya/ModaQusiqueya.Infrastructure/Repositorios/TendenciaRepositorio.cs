using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Api.Data;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<TendenciaModel>> ObtenerTodosAsync()
        {
            var tendencias = await _context.Tendencias.ToListAsync();
            return tendencias.Select(t => new TendenciaModel
            {
                Id = t.Id,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Temporada = t.Temporada
            }).ToList();
        }

        public async Task<TendenciaModel?> ObtenerPorIdAsync(int id)
        {
            var tendencia = await _context.Tendencias.FindAsync(id);
            if (tendencia == null) return null;

            return new TendenciaModel
            {
                Id = tendencia.Id,
                Nombre = tendencia.Nombre,
                Descripcion = tendencia.Descripcion,
                Temporada = tendencia.Temporada
            };
        }

        public async Task CrearAsync(TendenciaModel tendenciaModel)
        {
            var tendencia = new Tendencia
            {
                Nombre = tendenciaModel.Nombre,
                Descripcion = tendenciaModel.Descripcion,
                Temporada = tendenciaModel.Temporada
            };

            _context.Tendencias.Add(tendencia);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(TendenciaModel tendenciaModel)
        {
            var tendencia = await _context.Tendencias.FindAsync(tendenciaModel.Id);
            if (tendencia != null)
            {
                tendencia.Nombre = tendenciaModel.Nombre;
                tendencia.Descripcion = tendenciaModel.Descripcion;
                tendencia.Temporada = tendenciaModel.Temporada;

                _context.Tendencias.Update(tendencia);
                await _context.SaveChangesAsync();
            }
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

