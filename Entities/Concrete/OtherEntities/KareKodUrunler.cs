using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodUrunler : BaseEntity
    {
        public long Sn { get; set; }//
        public string Bn { get; set; }//
        public string Gtin { get; set; }//
        public DateTime Xd { get; set; }//
        public DateTime Md { get; set; }//
        public string QrCode { get; set; }//
        public int WoorId { get; set; }//
        public int PaletSn { get; set; }
        public int BoxSn { get; set; }
        public int PackSn { get; set; }
        public string PaletSscc { get; set; }
        public string BoxSscc { get; set; }
        public string PackSscc { get; set; }
    }
}
