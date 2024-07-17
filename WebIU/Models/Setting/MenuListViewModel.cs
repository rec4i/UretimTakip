using Entities.Concrete.VmDtos.SettingDto;

namespace WebIU.Models.Setting
{
    public class MenuListViewModel
    {
        public List<SideBarMenuItemDto> IsParents { get; internal set; }
        public List<SideBarMenuItemDto> Childs { get; internal set; }
    }
}
