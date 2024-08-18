using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodIsEmri : BaseEntity
    {
        public int BaseProductId { get; set; } // BASE_PRODUCT_ID
        public KareKodAnaUrun BaseProduct { get; set; }
        public DateTime CreatedDate { get; set; } // CREATED_DATE
        public DateTime? ExpirationDate { get; set; } // EXPIRATION_DATE (nullable)
        public string Lot { get; set; } // LOT (nullable)
        public int PlannedProduct { get; set; } // PLANNED_PRODUCT
        public int? PackCount { get; set; } // PACK_COUNT (nullable)
        public int BoxCount { get; set; } // BOX_COUNT
        public int PaletCount { get; set; } // PALET_COUNT
        public int? ProductPerPack { get; set; } // PRODUCT_PER_PACK (nullable)



        public int? ProductPerBox { get; set; } // PRODUCT_PER_BOX (nullable)
        public int BoxPerPalet { get; set; } // BOX_PER_PALET



        public int? PackPerBox { get; set; } // PACK_PER_BOX (nullable)
        public int OrderStatus { get; set; } // ORDER_STATUS
        public string? Description { get; set; } // DESCRIPTION (nullable)
    }
}
