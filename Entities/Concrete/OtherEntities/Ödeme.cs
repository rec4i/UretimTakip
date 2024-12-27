using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Ödeme : BaseEntity
    {

        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public int FaturaBaslıkId { get; set; }
        public FaturaBaslık FaturaBaslık { get; set; }

        public int Açıklama { get; set; }

        //1 Nakit
        //2 Kart
        //3 Çek
        public int ÖdemeTürü { get; set; }

        public decimal Tutar { get; set; }

        public int SeriNo { get; set; }
        public int ÖdemeSeriId { get; set; }
        public ÖdemeSeri ÖdemeSeri { get; set; }

    }
}
