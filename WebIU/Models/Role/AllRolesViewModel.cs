using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;

namespace WebIU.Models.Role
{
    public class AllRolesViewModel
    {
        public IQueryable<IdentityRole> Roles { get; set; }
    }
}