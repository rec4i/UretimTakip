using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodAnaUrun : BaseEntity
    {
        public string Name { get; set; } // NAME
        public string Unit { get; set; } // UNIT
        public string Gtin { get; set; } // GTIN
        public int? Origin { get; set; } // ORIGIN (nullable)
        public int RafCycleTime { get; set; } // RAF_CYCLE_TIME

        //1 YIL
        //2 AY
        //3 GÜN
        public string RafCycleUnit { get; set; } // RAF_CYCLE_UNIT
        public string ProductType { get; set; } // PRODUCT_TYPE
        public int? BoxesInPalet { get; set; } // BOXES_IN_PALET (nullable)
        public int? ProductInBox { get; set; } // PRODUCT_IN_BOX (nullable)
        public int? ProductsInPack { get; set; } // PRODUCTS_IN_PACK (nullable)
        public int? PacksInBox { get; set; } // PACKS_IN_BOX (nullable)
        public bool? HasPack { get; set; } // HAS_PACK (nullable)
    }
}
