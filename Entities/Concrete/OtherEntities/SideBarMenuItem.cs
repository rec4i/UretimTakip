using Entities.Abstract;
using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SideBarMenuItem : BaseEntity
    {

        public string Url { get; set; }
        public int Row { get; set; }
        public string IconCss { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public bool IsParent { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }



        [NotMapped]
        public SideBarMenuItem? Parent { get; set; }

        [NotMapped]
        public List<SideBarMenuItem> Children { get; set; }
    }
}
