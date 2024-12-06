using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class CariHareket : BaseEntity
    {
        //1 Para verdik
        //2 Para aldık
        public int HareketTürü { get; set; }

        //1 Nakit
        //2 Kart
        //3 Havale-EFT
        //4 Çek
        public int ÖdemeTürü { get; set; }

        public string ÇekNo { get; set; }
        public string ÇekGörselUrl { get; set; }
        public decimal Tutar { get; set; }


        public Cari Cari { get; set; }
        public int CariId { get; set; }
    }
}
