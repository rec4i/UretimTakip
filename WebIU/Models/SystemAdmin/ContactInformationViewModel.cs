using Entities.Concrete.VmDtos.SystemAdminDtos;
using Entities.Concrete.VmDtos.UserDtos;

namespace WebIU.Models.SystemAdmin
{
    public class ContactInformationViewModel
    {
        public ContactDto Contact { get; internal set; }
        public ShortUserInfoDto User { get; internal set; }
    }
}
