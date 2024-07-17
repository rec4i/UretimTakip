using DataAccess.Concrete.EntityFramework.DbContexts;
using DataAccess.Concrete.Seeds;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebIU.Extensions
{
    public static class IdentityDbContextSeedExtensions
    {
        public static async Task<IServiceCollection> IdentityDbContextSeedAsync(this IServiceCollection services)
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var loggerProvider = serviceProvider.GetRequiredService<ILoggerProvider>();
                var logger = loggerProvider.CreateLogger("app");
                try
                {
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = serviceProvider.GetRequiredService<UserManager<AppIdentityUser>>();
                    var applicationDbContext = serviceProvider.GetRequiredService<AppIdentityDbContext>();
                    await DefaultRolesSeed.SeedAsync(roleManager);
                    await DefaultUsersSeed.SeedImplementerUserAsync(userManager);
                    await DefaultUsersSeed.SeedSuperAdminUserAsync(userManager, roleManager);
                    applicationDbContext.Database.Migrate();
                    logger.LogInformation("Identity Data Seed Created");
                    logger.LogInformation("Application started");
                }
                catch (Exception ex)
                {
                    logger.LogError($"An error occured while identity seed process. Error: {ex.Message}");
                }
            }
            return services;
        }
    }
}
