using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.Account;

namespace WebIU.Models.ViewComponentModels
{
    public class MyAccountSideBarViewModel
    {
        public MyAccountDto User { get; internal set; }
        public List<string> Roles { get; internal set; }
        public string CountryName { get; internal set; }
        public Culture Culture { get; internal set; }
        public bool ItSelf { get; internal set; }
    }
}
