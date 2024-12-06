using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class DökümanSelectBoxItem : BaseEntity
    {
        public int DökümanAlanId { get; set; }
        public DökümanAlan DökümanAlan { get; set; }
        public string ItemValue { get; set; }
    }
}
