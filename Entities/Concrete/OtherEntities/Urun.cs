using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Urun : BaseEntity
    {
        public string Guid { get; set; }
        public int İşEmriId { get; set; }
        public İşEmri İşEmri { get; set; }

        public List<UrunAşamaları> UrunAşamalarıs { get; set; }
    }
}
