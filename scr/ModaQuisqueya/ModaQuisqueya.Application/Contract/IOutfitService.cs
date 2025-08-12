using ModaQuisqueya.Application.DTOs;

namespace ModaQuisqueya.Application.Contract
{
    public interface IOutfitService
    {
        Task ActualizarAsync(OutfitDto dto);
        Task AgregarAsync(OutfitDto dto);
        Task EliminarAsync(int id);
        Task<OutfitDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<OutfitDto>> ObtenerTodosAsync();
    }
}