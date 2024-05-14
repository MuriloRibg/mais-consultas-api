using mais_consultas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Provider> Providers { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Models.Appointment> Appointments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professional>()
                .HasOne(professional => professional.Provider)
                .WithOne(provider => provider.Professional)
                .HasForeignKey<Professional>(professional => professional.Id_Provider);
        }
    }
}