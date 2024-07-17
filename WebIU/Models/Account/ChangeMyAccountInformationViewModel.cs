
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.UserDtos;

namespace WebIU.Models.Account
{
    public class ChangeMyAccountInformationViewModel
    {
        public IFormFile? ImageFile { get; set; }
        public EditUserDto User { get;  set; }
        public IEnumerable<Culture>? Cultures { get; internal set; }
        public IEnumerable<Country>? Countries { get; internal set; }
    }
}
