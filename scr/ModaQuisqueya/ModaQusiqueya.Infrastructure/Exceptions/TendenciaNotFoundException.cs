using System;

namespace ModaQuisqueya.Infrastructure.Exceptions
{
    public class TendenciaNotFoundException : Exception
    {
        public TendenciaNotFoundException(int id)
            : base($"La tendencia con ID {id} no fue encontrada.")
        {
        }
    }
}
