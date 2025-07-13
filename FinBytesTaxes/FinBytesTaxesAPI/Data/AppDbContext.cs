using FinBytesTaxesAPI.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("taxes");

            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Vilnius" },
                new City() { Id = 2, Name = "Kaunas" },
                new City() { Id = 3, Name = "Panevežys" },
                new City() { Id = 4, Name = "Klaipėda" },
                new City() { Id = 5, Name = "Molėtai" },
                new City() { Id = 6, Name = "Varėna" }
            );
        }

        public DbSet<City> Cities { get; set; }

    }
}
