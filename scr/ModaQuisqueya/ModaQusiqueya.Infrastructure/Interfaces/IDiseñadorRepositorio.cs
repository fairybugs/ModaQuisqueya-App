using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface IDiseñadorRepositorio
    {
        Task ActualizarAsync(Diseñador diseñador);
        Task AgregarAsync(Diseñador diseñador);
        Task EliminarAsync(int id);
        Task<Diseñador?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Diseñador>> ObtenerTodosAsync();
    }
}