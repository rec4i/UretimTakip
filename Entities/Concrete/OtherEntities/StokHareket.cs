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

        public int? DepoId { get; set; }
        public Depo? Depo { get; set; }

        //1 Depo Stok Girişi
        //2 Depo Stok Çıkışı
        //3 Fatura Alış
        //4 Fatura Satış
        //5 Fatura İade
        public int? HareketTipi { get; set; }
        public decimal? Adet { get; set; }

        public int? FaturaBaslıkId { get; set; }
        public FaturaBaslık? FaturaBaslık { get; set; }
        public int? CariId { get; set; }
        public Cari? Cari { get; set; }

    }
}
