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

            modelBuilder.Entity<TaxType>().HasData(
                new TaxType() { Id = 1, Name = "Daily", Priority = 1 },
                new TaxType() { Id = 2, Name = "Weekly", Priority = 2 },
                new TaxType() { Id = 3, Name = "Monthly", Priority = 3 },
                new TaxType() { Id = 4, Name = "Yearly", Priority = 4 }
            );

            modelBuilder.Entity<CityTaxRule>().HasData(
                new CityTaxRule() { Id = 1, CityId = 2, TaxTypeId = 4, Rate = 3.3m, StartDate = new DateOnly (2025, 01, 01), EndDate = new DateOnly (2025, 12, 31)},
                new CityTaxRule() { Id = 2, CityId = 2, TaxTypeId = 3, Rate = 5m, StartDate = new DateOnly (2025, 06, 01), EndDate = new DateOnly (2025, 06, 30)},
                new CityTaxRule() { Id = 3, CityId = 2, TaxTypeId = 3, Rate = 4m, StartDate = new DateOnly (2025, 07, 01), EndDate = new DateOnly (2025, 07, 31)},
                new CityTaxRule() { Id = 4, CityId = 2, TaxTypeId = 3, Rate = 6m, StartDate = new DateOnly(2025, 08, 01), EndDate = new DateOnly(2025, 08, 31) },
                new CityTaxRule() { Id = 5, CityId = 2, TaxTypeId = 2, Rate = 2.5m, StartDate = new DateOnly (2025, 02, 09), EndDate = new DateOnly (2025, 02, 15)},
                new CityTaxRule() { Id = 6, CityId = 2, TaxTypeId = 2, Rate = 2.5m, StartDate = new DateOnly (2025, 03, 02), EndDate = new DateOnly (2025, 03, 08)},
                new CityTaxRule() { Id = 7, CityId = 2, TaxTypeId = 1, Rate = 1.5m, StartDate = new DateOnly (2025, 06, 01), EndDate = new DateOnly (2025, 06, 01)},
                new CityTaxRule() { Id = 8, CityId = 2, TaxTypeId = 1, Rate = 1.2m, StartDate = new DateOnly(2025, 10, 23), EndDate = new DateOnly (2025, 10, 23)}
            );
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
        public DbSet<CityTaxRule> CityTaxRules { get; set; }

    }
}
