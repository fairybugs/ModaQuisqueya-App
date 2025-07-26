namespace ModaQuisqueya.Application.DTOs
{
    public class TiendaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Teléfono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
    }
}
