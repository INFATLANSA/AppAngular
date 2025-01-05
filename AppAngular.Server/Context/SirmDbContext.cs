using AppAngular.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAngular.Server.Context
{
    public class SirmDbContext:DbContext
    {
        public SirmDbContext(DbContextOptions<SirmDbContext> options) : base(options) { }

        public DbSet<Parametro> Parametro { get; set; }    
        public DbSet<Catalogo> Catalogo { get; set; }

    }
}
