using System;

namespace ModaQuisqueya.Infrastructure.Exceptions
{
    public class TiendaNotFoundException : Exception
    {
        public TiendaNotFoundException(int id)
            : base($"La tienda con ID {id} no fue encontrada.")
        {
        }
    }
}
