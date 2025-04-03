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
        //6 Üretim Stok Kullanımı
        //7 Üretim Stok Üretimi
        public int? HareketTipi { get; set; }


        public decimal? Adet { get; set; }

        public int? FaturaBaslıkId { get; set; }
        public FaturaBaslık? FaturaBaslık { get; set; }
        public int? CariId { get; set; }
        public Cari? Cari { get; set; }

        public int? İşEmriDurumId { get; set; }
        public İşEmriDurum? İşEmriDurum { get; set; }



        public string? LotNo { get; set; }
        public DateTime? SonKullanmaTarihi { get; set; }

    }
}
