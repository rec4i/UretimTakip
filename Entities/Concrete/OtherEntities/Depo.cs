using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Depo : BaseEntity
    {
        public string DepoAdı { get; set; }
        public string? DepoAdres { get; set; }
        public List<Stok> Stoks { get; set; }
    }
}
