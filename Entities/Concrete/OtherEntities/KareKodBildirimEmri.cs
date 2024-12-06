using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class KareKodBildirimEmri : BaseEntity
    {

        /// <summary>
        /// 1 Üretim
        /// 2 Satış
        /// 3 Satış İptal
        /// 4 İhracat
        /// 5 İthalat
        /// 6 Dekativasyon
        /// 7 Mal Alım
        /// 8 Mal İade
        /// 9 Mal Devir
        /// 10 Mal Devir İptal 
        /// </summary>
        public int KareKodBildirimTürüId { get; set; }
        public KareKodBildirimTürü KareKodBildirimTürü { get; set; }


        public int KareKodAnaUrunId { get; set; }
        public KareKodAnaUrun KareKodAnaUrun { get; set; }


        public int? Adet { get; set; }

        public int? KareKodMüşteriId { get; set; }
        public KareKodMüşteri? KareKodMüşteri { get; set; }

        public DateTime? DökümanTarihi { get; set; }

        public string? DökümanNo { get; set; }

        public string? Sender { get; set; }
        public string? Receiver { get; set; }


        public int? KareKodDeaktivasyonTürüId { get; set; }
        public KareKodDeaktivasyonTürü? KareKodDeaktivasyonTürü { get; set; }

        public string? ReceiverDetail { get; set; }


        /// <summary>
        /// 0 Oluşturuldu
        /// 1 Bildirildi
        /// </summary>
        public int BildirimDurumu { get; set; }


        public string? Açıklama { get; set; }



        /// <summary>
        /// 0 Gönderilmedi
        /// 1 Gönderildi
        /// </summary>
        public int? PtsGönderimDurumu { get; set; }


        public string? FaturaNo { get; set; }
        public string? SiparişNo { get; set; }


    }
}
