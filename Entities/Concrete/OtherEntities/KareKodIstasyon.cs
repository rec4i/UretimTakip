using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodIstasyon : BaseEntity
    {
        public string IstasyonAdı { get; set; }
        public string IpAdresi { get; set; }
        public int Port { get; set; }
        public string? X1JetIpAdresi { get; set; }
        public string? YazıcıIpAdresi { get; set; }

        public int? KareKodIsEmriIstasyonMTMId { get; set; }
        public KareKodIsEmriIstasyonMTM? KareKodIsEmriIstasyonMTM { get; set; }


    }
}
