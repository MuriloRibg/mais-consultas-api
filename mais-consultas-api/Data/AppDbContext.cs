using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {
    }

    public DbSet<Professional> Professionals { get; set; }
}