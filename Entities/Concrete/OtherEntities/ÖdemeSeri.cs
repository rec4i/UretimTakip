using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class ÖdemeSeri : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }

        public List<FaturaBaslık> FaturaBaslıks { get; set; }
        public string SeriNo { get; set; }


        //1 Nakit Ödeme
        //2 Kart Ödeme
        //3 Çek Ödeme
        public int SeriTürü { get; set; }
    }
}
