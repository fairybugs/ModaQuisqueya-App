namespace ModaQuisqueya.Domain.Entities
{
    public class Outfit
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ocasion { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;

        //OJO: Esta es una relaciooooooon
        public int DisenadorId { get; set; }
        public Diseñador? Disenador { get; set; }
    }
}
