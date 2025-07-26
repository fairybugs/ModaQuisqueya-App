namespace ModaQuisqueya.Domain.Entities
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Teléfono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
    }
}
