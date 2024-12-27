using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Fiyat : BaseEntity
    {
        public decimal GeçerliFiyat { get; set; }

        public decimal GeçerliKdvOranı { get; set; }

        public int StokId { get; set; }
        public Stok Stok { get; set; }


    }
}
