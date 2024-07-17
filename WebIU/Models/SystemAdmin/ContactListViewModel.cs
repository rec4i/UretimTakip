using Entities.Concrete.VmDtos.SystemAdminDtos;
using Entities.Concrete.VmDtos.UserDtos;

namespace WebIU.Models.SystemAdmin
{
    public class ContactListViewModel
    {
        public List<ContactDto> ContactList { get; internal set; }
        public List<ShortUserInfoDto> Users { get; internal set; }
    }
}
