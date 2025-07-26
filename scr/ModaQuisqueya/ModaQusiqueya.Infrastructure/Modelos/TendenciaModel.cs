using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaQusiqueya.Infrastructure.Modelos
{
    public class TendenciaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Temporada { get; set; } = null!;
    }
}
