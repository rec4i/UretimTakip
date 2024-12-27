using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class FaturaDetay : BaseEntity
    {
        public int FaturaBaslıkId { get; set; }
        public FaturaBaslık FaturaBaslık { get; set; }

        public int StokId { get; set; }
        public Stok Stok { get; set; }

        public decimal Fiyat { get; set; }
        public decimal KdvOranı { get; set; }


        public decimal Adet { get; set; }

    }
}
