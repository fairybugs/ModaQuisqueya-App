
using System.ComponentModel.DataAnnotations.Schema;

namespace ModaQuisqueya.Domain.Entities
{
    public class Diseñador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
<<<<<<< Updated upstream
        public string Especialidad { get; set; } = null!;
        public string Biografía { get; set; } = null!;
=======

        public string Especialidad { get; set; } = null!;

        public string Biografia { get; set; } = null!;

>>>>>>> Stashed changes
        public string FotoUrl { get; set; } = null!;
    }
}

