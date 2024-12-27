using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class İş : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public string IşAdı { get; set; }
        public string Açıklama { get; set; }


        public int? TezgahId { get; set; }
        public Tezgah? Tezgah { get; set; }

        public List<Reçete_Iş_MTM> Reçete_Iş_MTMs { get; set; }


        //İş Tamamlanma Süresi Dakika Cinsinden
        public int? İşTamamlanmaSüresi { get; set; }
    }

}
