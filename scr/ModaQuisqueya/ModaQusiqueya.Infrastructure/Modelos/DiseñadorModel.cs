namespace ModaQuisqueya.Infrastructure.Modelos
{
    public class DiseñadorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;
        public string Biografía { get; set; } = null!;
        public string FotoUrl { get; set; } = null!;
    }
}