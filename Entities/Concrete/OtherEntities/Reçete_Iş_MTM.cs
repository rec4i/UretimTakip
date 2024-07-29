using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Reçete_Iş_MTM : BaseEntity
    {
        public Reçete? Reçete { get; set; }
        public int? ReçeteId { get; set; }
        public Iş? Iş { get; set; }
        public int? IşId { get; set; }

        public string İşAçıklama { get; set; }


        public int? KullanılacakDepoId { get; set; }
        public Depo? KullanılacakDepo { get; set; }

        public int? KullanılacakStokId { get; set; }
        public Stok? KullanılacakStok { get; set; }

        public decimal? KullanılacakStokAdeti { get; set; }




        public int? UretilecekDepoId { get; set; }
        public Depo? UretilecekDepo { get; set; }


        public int? UretilecekStokId { get; set; }
        public Stok? UretilecekStok { get; set; }
        public decimal? UretilecekStokAdeti { get; set; }






    }
}
