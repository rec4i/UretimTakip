using Entities.Concrete.BaseEntities;
using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reçete_Stok_MTM : BaseEntity
    {
        public int ReçeteId { get; set; }
        public Reçete Reçete { get; set; }


        public int StokId { get; set; }
        public Stok Stok { get; set; }

        public decimal KullanılacakAdet { get; set; }
    }
}
