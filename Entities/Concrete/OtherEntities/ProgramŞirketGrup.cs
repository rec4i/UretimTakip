using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class ProgramŞirketGrup : BaseEntity
    {
        public string Adı { get; set; }
        public int ŞirketAktifmi { get; set; }
        public string YetkiliİletişimNo { get; set; }
        public List<ProgramŞirketKullanıcı> ProgramŞirketKullanıcıs { get; set; }
    }
}
