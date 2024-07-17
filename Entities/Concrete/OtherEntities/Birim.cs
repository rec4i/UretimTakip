using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Birim : BaseEntity
    {
        public string BirimKodu { get; set; }
        public string DönüşümKodu { get; set; }
        public string DönüşümAçıklama { get; set; }

        public List<Stok> Stoks { get; set; }

    }
}
