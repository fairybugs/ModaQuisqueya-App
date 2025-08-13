using ModaQuisqueya.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface IOutfitRepositorio
    {
        Task<Outfit?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Outfit>> ObtenerTodosAsync();
        Task AgregarAsync(Outfit outfit);
        Task ActualizarAsync(Outfit outfit);
        Task EliminarAsync(int id);
    }
}