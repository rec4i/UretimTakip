using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Stok : BaseEntity
    {
        public string StokAdı { get; set; }
        public string Açıklama { get; set; }

        public int BirimId { get; set; }
        public Birim Birim { get; set; }

        public decimal StokAdeti { get; set; }
    }
}
