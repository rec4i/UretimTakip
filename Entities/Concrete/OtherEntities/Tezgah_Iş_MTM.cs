using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Tezgah_Iş_MTM : BaseEntity
    {
        public int TezgahId { get; set; }
        public Tezgah Tezgah { get; set; }

        public int IşId { get; set; }
        public İş Iş { get; set; }
    }
}
