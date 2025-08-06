namespace ModaQuisqueya.Application.DTOs
{
    public class TiendaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
    }
}
