using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodMüşteriYetkilileri : BaseEntity
    {
        public int? KareKodMüşteriId { get; set; }
        public KareKodMüşteri? KareKodMüşteri { get; set; }

        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
