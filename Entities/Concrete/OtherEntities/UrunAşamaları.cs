using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class UrunAşamaları : BaseEntity
    {
        public int? UrunId { get; set; }
        public Urun? Urun { get; set; }

        public int? IşId { get; set; }
        public Iş? Iş { get; set; }

        public int? İşEmriId { get; set; }
        public İşEmri? İşEmri { get; set; }

        public DateTime? İşeBaşlamaZamanı { get; set; }
        public DateTime? İşiBitirmeZamanı { get; set; }

        public string? İşiÜstlenenKullanıcıId { get; set; }
        public AppIdentityUser? İşiÜstlenenKullanıcı { get; set; }
        public bool TamamlanmaDurumu { get; set; }

    }
}
