using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface ITendenciaRepositorio
    {
        Task<Tendencia?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Tendencia>> ObtenerTodasAsync();
        Task AgregarAsync(Tendencia tendencia);
        Task ActualizarAsync(Tendencia tendencia);
        Task EliminarAsync(int id);
    }
}