using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Reçete_Iş_MTM_ÜretilecekStok : BaseEntity
    {

        public int? Reçete_Iş_MTMId { get; set; }
        public Reçete_Iş_MTM Reçete_Iş_MTM { get; set; }
        public int? DepoId { get; set; }
        public Depo? Depo { get; set; }

        public int? StokId { get; set; }
        public Stok? Stok { get; set; }
        public decimal? ÜretilecekStokMiktarı { get; set; }
    }
}
