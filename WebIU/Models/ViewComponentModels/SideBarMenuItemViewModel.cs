using Entities.Concrete;
using Tools.Concrete.HelperClasses.EntityHelpers;

namespace WebIU.Models.ViewComponentModels
{
    public class SideBarMenuItemViewModel
    {
        public IEnumerable<TreeItem<SideBarMenuItem>> MenuItems { get; internal set; }
        public string UserName { get; internal set; }
        public string UserId { get; internal set; }
        public string? UserImage { get; internal set; }
        public string UserRoleName { get; internal set; }
        public DateTime? LastLoginDate { get; internal set; }
    }
}
