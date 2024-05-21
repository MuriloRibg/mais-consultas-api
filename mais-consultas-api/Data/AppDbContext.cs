using mais_consultas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Provider>()
                .HasOne(provider => provider.Appointment)
                .WithOne(appointment => appointment.Provider)
                .HasForeignKey<Appointment>(appointment => appointment.Id_Provider);
            
            builder.Entity<Patient>()
                .HasOne(patient => patient.Appointment)
                .WithOne(appointment => appointment.Patient)
                .HasForeignKey<Appointment>(appointment => appointment.Id_Patient);
        }
    }
}