using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;

namespace Entities.Concrete.OtherEntities
{
    public class SıcakSatışAyar : BaseEntity
    {
        public string? UserId { get; set; }
        public AppIdentityUser? User { get; set; }
        public int? HızlıButonProfilId { get; set; }
        public string? CariKodu { get; set; }
        public string? TermalYazıcıIpAdresi { get; set; }
        public string? KrediKasaKodu { get; set; }
        public string? NakitKasaKodu { get; set; }
        public string? RivaDbYolu { get; set; }

        public string? RivaUser { get; set; }
        public string? RivaPass { get; set; }
    }
}
