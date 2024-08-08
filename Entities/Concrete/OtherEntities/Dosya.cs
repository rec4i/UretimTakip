using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Dosya : BaseEntity
    {
        //public int? ProgramŞirketGrupId { get; set; }
        //public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public int? ParentId { get; set; }
        public string? DosyaAdı { get; set; }
        public string? DosyaYolu { get; set; }
        public string? Guid { get; set; }
        public string? Açıklama { get; set; }

    }
}
