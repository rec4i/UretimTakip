using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.Account;
using Entities.Concrete.VmDtos.DoctorDtos;
using Entities.Concrete.VmDtos.ExportedFileDtos;
using Entities.Concrete.VmDtos.RoleDtos;
using Entities.Concrete.VmDtos.SettingDto;
using Entities.Concrete.VmDtos.SystemAdminDtos;
using Entities.Concrete.VmDtos.SystemUserLogDtos;
using Entities.Concrete.VmDtos.UnitDtos;
using Entities.Concrete.VmDtos.UserDtos;
using Entities.Concrete.VmDtos.UserLogDtos;
using Profile = AutoMapper.Profile;

namespace Business.Mappings
{

    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppIdentityUser, UserListDto>().ReverseMap();
            CreateMap<AppIdentityUser, UserDetailDto>().ReverseMap();
            CreateMap<AppIdentityUser, EditUserDto>().ReverseMap();
            CreateMap<AppIdentityUser, AddUserDto>().ReverseMap();
            CreateMap<AppIdentityUser, MyAccountDto>().ReverseMap();
            CreateMap<AppIdentityUser, ShortUserInfoDto>().ReverseMap();
            CreateMap<AppIdentityUser, EditRoleUsersDto>().ReverseMap();

            CreateMap<SideBarMenuItem, SideBarMenuItemDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();

            CreateMap<SystemUserLog, SystemUserLogListDto>().ReverseMap();
            CreateMap<SystemUserLog, SystemUserLogAddDto>().ReverseMap();


            CreateMap<UserLog, UserLogListDto>().ReverseMap();
            CreateMap<UserLog, UserLogAddDto>().ReverseMap();




            CreateMap<AddExportedFileDto, ExportedFile>().ReverseMap();
            CreateMap<ListExportedFileDto, ExportedFile>().ReverseMap();


            ////Unit
            //CreateMap<AddUnitDto, Unit>().ReverseMap();

            ////Doctor

            //CreateMap<AddDoctorDto, Doctor>().ReverseMap();




        }
    }
}
