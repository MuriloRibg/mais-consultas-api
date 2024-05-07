using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Provider> Provider { get; set; }
    }

    public DbSet<Professional> Professionals { get; set; }
}