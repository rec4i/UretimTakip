using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodDeaktivasyonTürü : BaseEntity
    {
        public string DeaktivasyonKodu { get; set; }
        public string Sebep { get; set; }
    }
}
