using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class FaturaSeri : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }

        public List<FaturaBaslık> FaturaBaslıks { get; set; }
        public string SeriNo { get; set; }

        //1 Alış Faturası
        //2 Satış Faturası
        //3 İade Faturası
        public int SeriTürü { get; set; }
    }
}
