using Entities.Concrete.Contants;
using Entities.Concrete.Enums;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Seeds
{
    public static class DefaultRolesSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = Roles.SuperAdmin.ToString(),
                Id = RoleIds.SuperAdmin
            });
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = Roles.Implementer.ToString(),
                Id = RoleIds.Implementer
            });
        }
    }
}
