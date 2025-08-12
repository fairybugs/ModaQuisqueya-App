using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.DTOs;
using ModaQuisqueya.Domain.Entities;
using ModaQuisqueya.Infrastructure.Interfaces;

namespace ModaQuisqueya.Application.Services
{
    public class DiseñadorService : IDiseñadorService
    {
        private readonly IDiseñadorRepositorio _repositorio;

        public DiseñadorService(IDiseñadorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<DiseñadorDto?> ObtenerPorIdAsync(int id)
        {
            var diseñador = await _repositorio.ObtenerPorIdAsync(id);
            if (diseñador == null) return null;

            return new DiseñadorDto
            {
                Id = diseñador.Id,
                Nombre = diseñador.Nombre,
                Especialidad = diseñador.Especialidad,
                Biografia = diseñador.Biografia,
                FotoUrl = diseñador.FotoUrl
            };
        }

        public async Task<IEnumerable<DiseñadorDto>> ObtenerTodosAsync()
        {
            var diseñadores = await _repositorio.ObtenerTodosAsync();
            return diseñadores.Select(d => new DiseñadorDto
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Especialidad = d.Especialidad,
                Biografia = d.Biografia,
                FotoUrl = d.FotoUrl
            });
        }

        public async Task AgregarAsync(DiseñadorDto dto)
        {
            var diseñador = new Diseñador
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Biografia = dto.Biografia,
                FotoUrl = dto.FotoUrl
            };

            await _repositorio.AgregarAsync(diseñador);
        }

        public async Task ActualizarAsync(DiseñadorDto dto)
        {
            var diseñador = new Diseñador
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad,
                Biografia = dto.Biografia,
                FotoUrl = dto.FotoUrl
            };

            await _repositorio.ActualizarAsync(diseñador);
        }

        public async Task EliminarAsync(int id)
        {
            await _repositorio.EliminarAsync(id);
        }
    }
}
