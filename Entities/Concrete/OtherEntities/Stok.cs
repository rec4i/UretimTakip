using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Stok : BaseEntity
    {
        public int? ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup? ProgramŞirketGrup { get; set; }
        public string StokAdı { get; set; }
        public string? Açıklama { get; set; }
        public int ÜstStokId { get; set; }
        public int? BirimId { get; set; }
        public Birim? Birim { get; set; }



        public string StokKodu { get; set; }

        //public decimal StokAdeti { get; set; }

        //public int? DepoId { get; set; }
        //public Depo? Depo { get; set; }

        public List<StokHareket>? StokHarekets { get; set; }

        public List<BlokBilgi>? BlokBilgis { get; set; }
    }
}
