using Entities.Concrete.Contants;
using Entities.Concrete.Enums;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class DefaultUsersSeed
    {
        public static async Task SeedImplementerUserAsync(UserManager<AppIdentityUser> userManager)
        {
            var defaultUser = new AppIdentityUser
            {
                UserName = "ImplementerUser",
                Email = "implementeruser@nagis.com",
                EmailConfirmed = true,
                CountryId = 1,
                CultureName = "tr-TR",
                Image = "DefaultImage.png",
                PhoneNumber = "111-",
                Job = "Electronics Engineer",
                AddedDate = DateTime.Now,
                Id = UserIds.AdminUser
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Test124*");
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.Implementer.ToString()});
            }
        }
        public static async Task SeedSuperAdminUserAsync(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new AppIdentityUser
            {
                UserName = "SuperAdminUser",
                Email = "superadminuser@nagis.com",
                EmailConfirmed = true,
                CountryId = 1,
                CultureName = "tr-TR",
                Image = "DefaultImage.png",
                PhoneNumber = "111-",
                Job = "Electronics Engineer",
                AddedDate = DateTime.Now,
                Id = UserIds.SuperAdminUser

            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Test124*");
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.SuperAdmin.ToString(), Roles.Implementer.ToString()});
            }
            await roleManager.SeedClaimsForSuperUser();
        }
        private static async Task SeedClaimsForSuperUser(this RoleManager<IdentityRole> roleManager)
        {
            var superAdminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            await roleManager.AddPermissionClaims(superAdminRole);
            var adminRole = await roleManager.FindByNameAsync(Roles.Implementer.ToString());
            await roleManager.AddPermissionClaimsImplementer(adminRole);
        }
        private static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permission.GetPermissions();
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(p => p.Type == "Permission" && p.Value == permission))
                    await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permission));
            }
        }
        private static async Task AddPermissionClaimsImplementer(this RoleManager<IdentityRole> roleManager, IdentityRole role)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = PermissionImplementer.GetPermissions();
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(p => p.Type == "Permission" && p.Value == permission))
                    await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("Permission", permission));
            }
        }
    }
}
