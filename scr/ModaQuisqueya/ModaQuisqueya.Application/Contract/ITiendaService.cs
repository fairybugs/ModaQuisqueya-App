using ModaQuisqueya.Application.DTOs;

namespace ModaQuisqueya.Application.Contract
{
    public interface ITiendaService
    {
        Task ActualizarAsync(TiendaDto dto);
        Task AgregarAsync(TiendaDto dto);
        Task EliminarAsync(int id);
        Task<TiendaDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TiendaDto>> ObtenerTodasAsync();
    }
}