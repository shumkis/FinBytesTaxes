using FinBytesTaxesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FinBytesTaxesAPI.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                var dbContext = services.GetRequiredService<AppDbContext>();

                dbContext.Database.Migrate();
                logger.LogInformation("Database migrated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while applying database migrations.");
                throw;
            }
        }
    }

}
