using Entities.Concrete.OtherEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class UserLog : LogBaseEntity
    {
        public string ChangeUserId { get; set; }
    }
}
