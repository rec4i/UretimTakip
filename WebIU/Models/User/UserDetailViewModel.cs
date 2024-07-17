using Entities.Concrete.VmDtos.UserDtos;
using WebIU.Models.Account;

namespace WebIU.Models.User
{
    public class UserDetailViewModel
    {
        public UserDetailDto User { get; internal set; }
        public bool Itself { get; internal set; }
        public string UserId { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public ChangeMyAccountInformationViewModel ChangeUserInformationViewModel { get; internal set; }
    }
}
