using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class İşEmri : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }

        public Reçete Reçete { get; set; }
        public int ReçeteId { get; set; }
        public string Açıklama { get; set; }
        public string İşEmriAdı { get; set; }
        public int HedefÜretim { get; set; }

        public List<Urun> Uruns { get; set; }

    }
}
