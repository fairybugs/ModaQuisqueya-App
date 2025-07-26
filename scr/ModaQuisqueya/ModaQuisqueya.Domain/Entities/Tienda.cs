using System.ComponentModel.DataAnnotations.Schema;

namespace ModaQuisqueya.Domain.Entities
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string SitioWeb { get; set; } = null!;
    }
}
