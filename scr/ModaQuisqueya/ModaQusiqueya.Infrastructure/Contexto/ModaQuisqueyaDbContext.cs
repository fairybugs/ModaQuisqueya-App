using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModaQuisqueya.Api.Data
{
    public class ModaQuisqueyaDbContext : DbContext
    {
        public ModaQuisqueyaDbContext(DbContextOptions<ModaQuisqueyaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Diseñador> Diseñadores { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Tendencia> Tendencias { get; set; }
        public DbSet<Outfit> Outfits { get; set; }

    }
}

