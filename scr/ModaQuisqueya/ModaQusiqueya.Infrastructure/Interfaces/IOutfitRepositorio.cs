using ModaQuisqueya.Infrastructure.Entities;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface IOutfitRepositorio
    {
        Task ActualizarAsync(Outfit outfit);
        Task AgregarAsync(Outfit outfit);
        Task EliminarAsync(int id);
        Task<Outfit?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Outfit>> ObtenerTodosAsync();
    }
}