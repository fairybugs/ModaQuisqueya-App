using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Application.Contract
{
    public interface IOutfitService
    {
        Task<OutfitDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<OutfitDto>> ObtenerTodosAsync();
        Task AgregarAsync(OutfitDto dto);
        Task ActualizarAsync(OutfitDto dto);
        Task EliminarAsync(int id);
    }
}

