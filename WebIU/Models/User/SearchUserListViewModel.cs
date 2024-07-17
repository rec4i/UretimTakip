using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.UserDtos;

namespace WebIU.Models.User
{
    public class SearchUserListViewModel
    {
        public UserSearchDto Search { get; set; }
        public List<UserListDto>? Users { get;  set; }
        public List<Country>? Countries { get; internal set; }
        public List<Culture>? Cultures { get; internal set; }
    }
}
