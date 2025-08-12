using ModaQuisqueya.Application.DTOs;

namespace ModaQuisqueya.Application.Contract
{
    public interface ITendenciaService
    {
        Task ActualizarAsync(TendenciaDto dto);
        Task AgregarAsync(TendenciaDto dto);
        Task EliminarAsync(int id);
        Task<TendenciaDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TendenciaDto>> ObtenerTodasAsync();
    }
}