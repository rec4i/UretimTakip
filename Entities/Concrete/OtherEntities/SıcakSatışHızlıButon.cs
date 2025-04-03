using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class SıcakSatışHızlıButon : BaseEntity
    {
        public string? ButonRengi { get; set; }
        public string? ButonAdı { get; set; }
        public int? ParentId { get; set; }
        public int? RivaStokId { get; set; }
        public string? StokAdı { get; set; }


        public SıcakSatışButonProfil? sıcakSatışButonProfil { get; set; }
        public int? sıcakSatışButonProfilId { get; set; }
    }
}
