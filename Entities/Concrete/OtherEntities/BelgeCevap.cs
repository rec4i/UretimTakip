using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class BelgeCevap : BaseEntity
    {
        public int? BelgeSoruId { get; set; }
        public BelgeSoru? BelgeSoru { get; set; }


        public int? EvetHayırCevap { get; set; }


        public string? TextAreaCevap { get; set; }
        public DateTime? TarihCevap { get; set; }




    }
}
