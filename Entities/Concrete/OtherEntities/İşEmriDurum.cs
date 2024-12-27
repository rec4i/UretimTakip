using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class İşEmriDurum : BaseEntity
    {
        public int? İşEmriId { get; set; }
        public İşEmri? İşEmri { get; set; }

        public int? Reçete_Iş_MTMId { get; set; }
        public Reçete_Iş_MTM Reçete_Iş_MTM { get; set; }



        /// <summary>
        /// 1 İş Başlamadı 
        /// 2 Devam Ediyor
        /// 3 Tamamlandı
        /// </summary>
        public int? TamamlanmaDurum { get; set; }

        //[ForeignKey("Yapılacak_İş")]

        public int? YapılacakİşId { get; set; }
        public İş? Yapılacakİş { get; set; }


        public DateTime BaşlamaTarihi { get; set; }
        public DateTime BitişTarihi { get; set; }


        //public DateTime HedefBitişTarihi { get; set; }
        //public DateTime HedefBaşlamaTarihi { get; set; }


    }
}
