using Microsoft.EntityFrameworkCore;
using RegistrationValidationApp.Models;
 

namespace RegistrationValidationApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
        public DbSet<Vehicle> Registrations { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, RegistrationNumber = "ABC123", Electrified = "true" },
                new Vehicle { Id = 2, RegistrationNumber = "XYZ789", Electrified = "false" },
                new Vehicle { Id = 3, RegistrationNumber = "LMN456", Electrified = "true" }
            );
        }
    }
}