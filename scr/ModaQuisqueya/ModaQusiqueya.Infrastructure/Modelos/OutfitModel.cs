using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModaQusiqueya.Infrastructure.Modelos
{
    internal class OutfitModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
    }
}
