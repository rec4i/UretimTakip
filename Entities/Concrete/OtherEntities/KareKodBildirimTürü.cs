using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodBildirimTürü : BaseEntity
    {
        public string BildirimTürü { get; set; }
        public string BildirimTürüKodu { get; set; }
    }
}
