using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodMüşteri : BaseEntity
    {
        public string Adı { get; set; }
        public string GLN { get; set; }
        public string ToGLN { get; set; }
        public string Adres { get; set; }

        public List<KareKodMüşteriYetkilileri>? KareKodMüşteriYetkilileris { get; set; }
    }
}
