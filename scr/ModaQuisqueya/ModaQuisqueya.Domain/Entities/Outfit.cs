using ModaQuisqueya.Domain.Entities;

namespace ModaQuisqueya.Infrastructure.Entities
{
    public class Outfit
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Ocasion { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;

        // Relación con Diseñador
        public int DisenadorId { get; set; }
        public Diseñador? Disenador { get; set; }
    }
}

