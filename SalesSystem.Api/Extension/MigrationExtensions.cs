using Microsoft.EntityFrameworkCore;
using SalesSystem.Shared.Infrastructure;

namespace SalesSystem.Api.Extension
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();

            ApplicationDbContext dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

            dbContext.Database.Migrate();
        }
    }
}
