using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.UserDtos;
using System.Security.Claims;

namespace WebIU.Models.Role
{
    public class RoleEditViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public IList<ShortUserInfoDto>? Users { get; internal set; }
        public IList<Claim>? Permissions { get; internal set; }
    }
}