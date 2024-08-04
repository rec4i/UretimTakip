using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Cari : BaseEntity
    {

        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }

        public string Ad { get; set; }
        public string Adres { get; set; }


        //1 Müşteri
        //2 Tedarikçi
        public int Tür { get; set; }

        public string CariKodu { get; set; }
    }
}
