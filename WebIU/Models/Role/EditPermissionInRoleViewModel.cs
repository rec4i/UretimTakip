using Entities.Concrete.VmDtos.RoleDtos;

namespace WebIU.Models.Role
{
    public class EditPermissionInRoleViewModel
    {
        public List<EditPermissionInRoleDto> Permissions { get;  set; }
        public string RoleId { get;  set; }
    }
}
