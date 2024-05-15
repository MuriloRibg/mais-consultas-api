using mais_consultas_api.Models;
using Microsoft.EntityFrameworkCore;

namespace mais_consultas_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Models.Appointment> Appointments { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Models.Provider> Providers { get; set; }
        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Provider>()
                .HasOne(provider => provider.Professional)
                .WithOne(professional => professional.Provider)
                .HasForeignKey<Professional>(professional => professional.Id_Provider);
            
            builder.Entity<Service>()
                .HasOne(service => service.Professional)
                .WithOne(professional => professional.Service)
                .HasForeignKey<Professional>(professional => professional.Id_Service);
            
            builder.Entity<Models.Provider>()
                .HasOne(provider => provider.Appointment)
                .WithOne(appointment => appointment.Provider)
                .HasForeignKey<Models.Appointment>(appointment => appointment.Id_Provider);
            
            builder.Entity<Professional>()
                .HasOne(professional => professional.Appointment)
                .WithOne(appointment => appointment.Professional)
                .HasForeignKey<Models.Appointment>(appointment => appointment.Id_Professional);
            
            builder.Entity<Patient>()
                .HasOne(patient => patient.Appointment)
                .WithOne(appointment => appointment.Patient)
                .HasForeignKey<Models.Appointment>(appointment => appointment.Id_Patient);
        }
    }
}