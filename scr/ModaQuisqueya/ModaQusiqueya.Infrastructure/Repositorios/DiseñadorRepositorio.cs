using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Api.Data;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Modelos;

namespace ModaQuisqueya.Infrastructure.Repositorios
{
    public class DiseñadorRepositorio : IDiseñadorRepositorio
    {
        private readonly ModaQuisqueyaDbContext _context;

        public DiseñadorRepositorio(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiseñadorModel>> ObtenerTodosAsync()
        {
            var diseñadores = await _context.Diseñadores.ToListAsync();
            return diseñadores.Select(d => new DiseñadorModel
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Especialidad = d.Especialidad
            }).ToList();
        }

        public async Task<DiseñadorModel?> ObtenerPorIdAsync(int id)
        {
            var diseñador = await _context.Diseñadores.FindAsync(id);
            if (diseñador == null)
                return null;

            return new DiseñadorModel
            {
                Id = diseñador.Id,
                Nombre = diseñador.Nombre,
                Especialidad = diseñador.Especialidad
            };
        }

        public async Task CrearAsync(DiseñadorModel diseñadorModel)
        {
            var diseñador = new Diseñador
            {
                Nombre = diseñadorModel.Nombre,
                Especialidad = diseñadorModel.Especialidad
            };

            _context.Diseñadores.Add(diseñador);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(DiseñadorModel diseñadorModel)
        {
            var diseñador = await _context.Diseñadores.FindAsync(diseñadorModel.Id);
            if (diseñador != null)
            {
                diseñador.Nombre = diseñadorModel.Nombre;
                diseñador.Especialidad = diseñadorModel.Especialidad;

                _context.Diseñadores.Update(diseñador);
                await _context.SaveChangesAsync();
            }
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
