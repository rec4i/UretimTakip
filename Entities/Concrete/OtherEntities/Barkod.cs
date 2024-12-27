using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Barkod : BaseEntity
    {

        public int ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup ProgramŞirketGrup { get; set; }

        public string İçerik { get; set; }
        public int StokId { get; set; }
        public Stok Stok { get; set; }
    }
}
