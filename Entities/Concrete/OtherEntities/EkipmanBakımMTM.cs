using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class EkipmanBakımMTM : BaseEntity
    {
        public int EkipmanBakımId { get; set; }
        public EkipmanBakım EkipmanBakım { get; set; }


        public int EkipmanId { get; set; }
        public Ekipman Ekipman { get; set; }
    }
}
