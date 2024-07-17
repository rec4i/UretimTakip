using Entities.Concrete.VmDtos.RoleDtos;

namespace WebIU.Models.Role
{
    public class EditUserInRoleViewModel
    {
        public string RoleId { get; set; }
        public List<EditRoleUsersDto> Users { get;  set; }
    }
}