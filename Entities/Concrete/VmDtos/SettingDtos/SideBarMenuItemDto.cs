using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.SettingDto
{
    public class SideBarMenuItemDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Row { get; set; }
        public string IconCss { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public bool IsParent { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
    }
}
