namespace ModaQuisqueya.Domain.Entities
{
    public class Tendencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public string Temporada { get; set; } = null!;
    }
}
