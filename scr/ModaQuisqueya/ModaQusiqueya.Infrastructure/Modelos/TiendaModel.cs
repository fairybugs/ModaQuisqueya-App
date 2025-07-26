namespace ModaQuisqueya.Infrastructure.Modelos
{
    public class TiendaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string SitioWeb { get; set; } = null!;
    }
}
