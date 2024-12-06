using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodBildirimUrun : BaseEntity
    {
        public int KareKodUrunlerId { get; set; }
        public KareKodUrunler KareKodUrunler { get; set; }


    }
}
