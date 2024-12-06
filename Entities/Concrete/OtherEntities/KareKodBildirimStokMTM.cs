using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodBildirimStokMTM : BaseEntity
    {
        public int? KareKodBildirimEmriId { get; set; }
        public KareKodBildirimEmri? KareKodBildirimEmri { get; set; }


        public int? KareKodStokId { get; set; }
        public KareKodStok? KareKodStok { get; set; }


        public int? BildirimDurumu { get; set; }
    }
}
