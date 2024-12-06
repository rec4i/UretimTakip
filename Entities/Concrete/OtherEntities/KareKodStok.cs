using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodStok : BaseEntity
    {
        public long Sn { get; set; }//
        public string Bn { get; set; }//
        public string Gtin { get; set; }//
        public DateTime Xd { get; set; }//
        public DateTime Md { get; set; }//
        public string QrCode { get; set; }//
        public string PaletSscc { get; set; }//
        public string BoxSscc { get; set; }//
        public string? PackSscc { get; set; }
        public int InStock { get; set; }
        public int NotificationStatus { get; set; }
        public string? NotificationId { get; set; }
    }
}
