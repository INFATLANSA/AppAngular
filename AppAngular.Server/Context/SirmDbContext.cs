using AppAngular.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAngular.Server.Context
{
    public class SirmDbContext:DbContext
    {
        public SirmDbContext(DbContextOptions<SirmDbContext> options) : base(options) { }

        DbSet<Parametro> Parametro { get; set; }    

    }
}
