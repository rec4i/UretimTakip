using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Tezgah : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public string TezgahAdı { get; set; }
        public string Açıklama { get; set; }
        public string? Guid { get; set; }
        public List<Reçete_Tezgah_MTM> Reçete_Tezgah_MTMs { get; set; }
        public List<Tezgah_Iş_MTM> Tezgah_Iş_MTMs { get; set; }


    }
}
