using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class FaturaBaslık : BaseEntity
    {

        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }

        public int CariId { get; set; }
        public Cari Cari { get; set; }

        //1 Alış Faturası
        //2 Satış Faturası
        //3 İade Faturası
        public int FaturaTürü { get; set; }
        public string FaturaNo { get; set; }
        public List<FaturaDetay> FaturaDetays { get; set; }


        public int SeriNo { get; set; }
        public int FaturaSeriId { get; set; }
        public FaturaSeri FaturaSeri { get; set; }

    }
}
