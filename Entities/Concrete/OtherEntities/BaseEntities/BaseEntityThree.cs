using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities.BaseEntities
{
    public class BaseEntityThree:IEntity
    {
        public int Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? SystemUserId { get; set; }
    }
}
