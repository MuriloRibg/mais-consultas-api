using mais_consultas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Provider>()
                .HasOne(provider => provider.Professional)
                .WithOne(professional => professional.Provider)
                .HasForeignKey<Professional>(professional => professional.Id_Provider);
        }

        public DbSet<Models.Provider> Providers { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
