using System.ComponentModel.DataAnnotations.Schema;

namespace ModaQuisqueya.Domain.Entities
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
