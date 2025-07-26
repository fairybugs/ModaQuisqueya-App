using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModaQuisqueya.Infrastructure.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.Interfaces
{
    public interface IDiseñadorRepositorio
    {
        Task<List<DiseñadorModel>> ObtenerTodosAsync();
        Task<DiseñadorModel?> ObtenerPorIdAsync(int id);
        Task CrearAsync(DiseñadorModel diseñador);
        Task ActualizarAsync(DiseñadorModel diseñador);
        Task EliminarAsync(int id);
    }
}

