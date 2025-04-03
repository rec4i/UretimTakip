using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class RivaFatura : BaseEntity
    {
        public DateTime OluşturmaTarihi { get; set; }
        public string BelgeNo { get; set; }
        public string RivaFaturaId { get; set; }
    }
}
