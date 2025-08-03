using ModaQuisqueya.Application.DTOs;

namespace ModaQuisqueya.Application.Contract
{
    public interface IDiseñadorService
    {
        Task ActualizarAsync(DiseñadorDto dto);
        Task AgregarAsync(DiseñadorDto dto);
        Task EliminarAsync(int id);
        Task<DiseñadorDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<DiseñadorDto>> ObtenerTodosAsync();
    }
}