using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaQuisqueya.Application.DTOs
{
    public class TendenciaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public string Temporada { get; set; } = null!;
    }
}
