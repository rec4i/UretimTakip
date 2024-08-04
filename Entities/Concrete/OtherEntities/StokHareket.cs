using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class StokHareket : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public int? StokId { get; set; }
        public Stok? Stok { get; set; }

        //1 Depo Stok Girişi
        //2 Depo Stok Çıkışı
        ////3 Cari Satış
        ////4 Ürün Satın Alma 

        public int? DepoId { get; set; }
        public Depo? Depo { get; set; }

        public int? HareketTipi { get; set; }

        public decimal? Adet { get; set; }


    }
}
