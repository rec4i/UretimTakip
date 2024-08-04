using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Lisans : BaseEntity
    {
        public string LisansNo { get; set; }

        public string KullananFirma { get; set; }

        public string Aktifmi { get; set; }
    }
}
