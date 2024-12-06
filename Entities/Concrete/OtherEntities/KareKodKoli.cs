using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodKoli : BaseEntity
    {
        public int? KareKodIsEmriId { get; set; }
        public KareKodIsEmri? KareKodIsEmri { get; set; }

        public int PaletSeriNo { get; set; }
        public int SeriNo { get; set; }
        public string SSCC { get; set; }

    }
}
