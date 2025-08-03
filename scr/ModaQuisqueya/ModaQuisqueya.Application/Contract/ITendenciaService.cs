using ModaQuisqueya.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Application.Contract
{
    public interface ITendenciaService
    {
        Task<TendenciaDto?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TendenciaDto>> ObtenerTodasAsync();
        Task AgregarAsync(TendenciaDto dto);
        Task ActualizarAsync(TendenciaDto dto);
        Task EliminarAsync(int id);
    }
}
