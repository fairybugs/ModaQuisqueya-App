using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Repositorios;
using System;
using System.Threading.Tasks;

namespace ModaQuisqueya.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ModaQuisqueyaDbContext _context;

        private IDiseñadorRepositorio? _diseñadores;
        private IOutfitRepositorio? _outfits;
        private ITendenciaRepositorio? _tendencias;
        private ITiendaRepositorio? _tiendas;

        public UnitOfWork(ModaQuisqueyaDbContext context)
        {
            _context = context;
        }

        public IDiseñadorRepositorio Diseñadores => _diseñadores ??= new DiseñadorRepositorio(_context);
        public IOutfitRepositorio Outfits => _outfits ??= new OutfitRepositorio(_context);
        public ITendenciaRepositorio Tendencias => _tendencias ??= new TendenciaRepositorio(_context);
        public ITiendaRepositorio Tiendas => _tiendas ??= new TiendaRepositorio(_context);

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
