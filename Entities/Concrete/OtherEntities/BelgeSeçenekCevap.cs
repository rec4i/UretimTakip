using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class BelgeSeçenekCevap : BaseEntity
    {
        public int? BelgeSoruSeçenekId { get; set; }
        public BelgeSoruSeçenek BelgeSoruSeçenek { get; set; }

        public string? VerilenCevap { get; set; }
    }
}
