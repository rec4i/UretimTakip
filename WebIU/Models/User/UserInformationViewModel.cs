using Entities.Concrete.VmDtos.UserDtos;

namespace WebIU.Models.User
{
    public class UserInformationViewModel
    {
        public UserDetailDto User { get; internal set; }
        public string CountryName { get; internal set; }
        public string CultureName { get; internal set; }
        public string AddedUserName { get; internal set; }
        public string UpdatedUserName { get; internal set; }
    }
}
