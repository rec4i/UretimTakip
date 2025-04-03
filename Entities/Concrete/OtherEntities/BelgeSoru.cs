using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class BelgeSoru : BaseEntity
    {
        /// <summary>
        /// 1 Sabit Alan --
        /// 2 Evet Hayır --
        /// 3 Text Area Doldurma --
        /// 4 Seçenekli --
        /// 5 Tarih Girme
        /// </summary>

        public int? BelgeSoruTürü { get; set; }
        public string? Açıklama { get; set; }

        public string? Soru { get; set; }

        //public string? SabitAlanYazısı { get; set; }
        //public string? EvetHayırSorusu { get; set; }
        //public string? TabloBaşlığı { get; set; }




        /// <summary>
        /// 0 Hayır
        /// 1 Evet
        /// </summary>
        public int? DahaSonradanEklenebilirmi { get; set; }

        /// <summary>
        /// 0 Hayır
        /// 1 Evet
        /// 2 Hepsi Seçili Gelsin
        /// </summary>
        public int? SeçenkelerSeçilebilir { get; set; }


        public int? BelgeId { get; set; }
        public Belge? Belge { get; set; }


    }
}
