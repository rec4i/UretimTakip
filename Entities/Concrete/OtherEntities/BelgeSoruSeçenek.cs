using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class BelgeSoruSeçenek : BaseEntity
    {
        public int? BelgeSoruId { get; set; }
        public BelgeSoru BelgeSoru { get; set; }
        public string? Seçenek { get; set; }
    }
}
