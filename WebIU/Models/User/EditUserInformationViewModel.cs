using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace WebIU.Models.User
{
    public class EditUserInformationViewModel
    {
        public EditUserDto User { get; set; }
        public List<string> RoleNames { get; set; }
        public List<IdentityRole>? Roles { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IEnumerable<Country>? Countries { get; internal set; }
        public List<Culture>? Cultures { get; internal set; }
        public List<Entities.Concrete.OtherEntities.Profile>? Profiles { get; set; }
    }
}
