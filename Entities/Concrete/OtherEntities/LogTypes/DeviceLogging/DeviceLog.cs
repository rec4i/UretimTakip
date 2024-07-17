using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities.LogTypes.DeviceLogging
{
    public class DeviceLog
    {
        public DateTime UpdateDate { get; set; }
        public string DeviceId { get; set; }
        public string AndroidUID { get; set; }
        public string DeviceVersion { get; set; }
        public string Descripton { get; set; }
    }
}
