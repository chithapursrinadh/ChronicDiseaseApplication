using ChronicDiseaseApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChronicDiseaseApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<HealthMetric> HealthMetrics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
