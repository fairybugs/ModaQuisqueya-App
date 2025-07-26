
using System.ComponentModel.DataAnnotations.Schema;

namespace ModaQuisqueya.Domain.Entities
{
    public class Diseñador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!;

        public string Biografia { get; set; } = null!;

        public string FotoUrl { get; set; } = null!;
    }
}

