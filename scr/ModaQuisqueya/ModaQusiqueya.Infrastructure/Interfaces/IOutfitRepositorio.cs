using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface IOutfitRepositorio
    {
        Task<List<OutfitModel>> ObtenerTodosAsync();
        Task<OutfitModel?> ObtenerPorIdAsync(int id);
        Task CrearAsync(OutfitModel outfit);
        Task ActualizarAsync(OutfitModel outfit);
        Task EliminarAsync(int id);
    }
}
