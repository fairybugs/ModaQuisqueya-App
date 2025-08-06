using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface ITendenciaRepositorio
    {
        Task ActualizarAsync(Tendencia tendencia);
        Task AgregarAsync(Tendencia tendencia);
        Task EliminarAsync(int id);
        Task<Tendencia?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Tendencia>> ObtenerTodasAsync();
    }
}