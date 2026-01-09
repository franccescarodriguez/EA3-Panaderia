using Microsoft.EntityFrameworkCore;
using Panaderia.Api.Models;

namespace Panaderia.Api.Data
{
    public class PanaderiaDbContext : DbContext
    {
        public PanaderiaDbContext(DbContextOptions<PanaderiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
