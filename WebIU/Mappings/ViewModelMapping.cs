using AutoMapper;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.UserDtos;
using WebIU.Models.Account;
using WebIU.Models.User;

namespace WebIU.Mappings
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<ChangeMyAccountInformationViewModel, UserDetailDto>().ReverseMap();
            CreateMap<AddUserViewModel, AppIdentityUser>().ReverseMap();
        }
    }
}
