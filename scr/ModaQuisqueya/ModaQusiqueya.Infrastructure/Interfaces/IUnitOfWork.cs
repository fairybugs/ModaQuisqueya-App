using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModaQuisqueya.Infrastructure.Interfaces;

namespace ModaQuisqueya.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDiseñadorRepositorio Diseñadores { get; }
        IOutfitRepositorio Outfits { get; }
        ITendenciaRepositorio Tendencias { get; }
        ITiendaRepositorio Tiendas { get; }

        Task<int> GuardarCambiosAsync();
    }
}