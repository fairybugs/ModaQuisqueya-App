using ModaQuisqueya.Infrastructure.Modelos;
using ModaQusiqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface ITendenciaRepositorio
    {
        Task<List<TendenciaModel>> ObtenerTodosAsync();
        Task<TendenciaModel?> ObtenerPorIdAsync(int id);
        Task CrearAsync(TendenciaModel tendencia);
        Task ActualizarAsync(TendenciaModel tendencia);
        Task EliminarAsync(int id);
    }
}
