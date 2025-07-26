using System;

namespace ModaQuisqueya.Infrastructure.Exceptions
{
    public class OutfitNotFoundException : Exception
    {
        public OutfitNotFoundException(int id)
            : base($"El outfit con ID {id} no fue encontrado.")
        {
        }
    }
}
