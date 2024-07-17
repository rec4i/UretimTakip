using Entities.Concrete.VmDtos.SettingDto;

namespace WebIU.Models.Setting
{
    public class MenuListChildItemViewModel
    {
        public int ParentId { get; set; }
        public List<SideBarMenuItemDto> IsParents { get; internal set; }
        public List<SideBarMenuItemDto> Childs { get; internal set; }

    }
}
