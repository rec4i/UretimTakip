using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class Reçete_İş_MTM_DoldurlacakDöküman : BaseEntity
    {
        public int? Reçete_Iş_MTMId { get; set; }
        public Reçete_Iş_MTM? Reçete_Iş_MTM { get; set; }

        public int? BelgeId { get; set; }
        public Belge? Belge { get; set; }

    }
}
