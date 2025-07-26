using System;

namespace ModaQuisqueya.Infrastructure.Exceptions
{
    public class DiseñadorNotFoundException : Exception
    {
        public DiseñadorNotFoundException(int id)
            : base($"El diseñador con ID {id} no fue encontrado.")
        {
        }
    }
}

