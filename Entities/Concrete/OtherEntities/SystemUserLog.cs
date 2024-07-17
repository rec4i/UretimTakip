using Entities.Concrete.OtherEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class SystemUserLog : LogBaseEntity
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string TrxResult { get; set; }
        public string IPAdress { get; set; }
    }
}
