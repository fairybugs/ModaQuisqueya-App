using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Modelos
{
    public class Outfit
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Ocasion { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
    }
}

