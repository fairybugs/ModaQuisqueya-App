using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface ITiendaRepositorio
    {
        Task ActualizarAsync(Tienda tienda);
        Task AgregarAsync(Tienda tienda);
        Task EliminarAsync(int id);
        Task<Tienda?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Tienda>> ObtenerTodasAsync();
    }
}