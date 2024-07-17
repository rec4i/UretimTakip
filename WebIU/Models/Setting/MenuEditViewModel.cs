using Entities.Concrete.VmDtos;

namespace WebIU.Models.Setting
{
    public class MenuEditViewModel
    {
        //public SideBarMenuItemDto? IsParent { get;  set; }
        //public List<SideBarMenuItemDto>? Childs { get;  set; }
        public string Url { get; set; }
        //public int Row { get; set; }
        public string IconCss { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
        public int OrderCount { get; set; }
    }
}
