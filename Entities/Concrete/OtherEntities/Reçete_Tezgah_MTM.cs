using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Reçete_Tezgah_MTM : BaseEntity
    {
        public Reçete? Reçete { get; set; }
        public int? ReçeteId { get; set; }
        public Tezgah? Tezgah { get; set; }
        public int? TezgahId { get; set; }

    }
}
