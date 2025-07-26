using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Entities
{
    public class Outfit
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
    }

}

