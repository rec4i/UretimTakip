using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.SystemUserLogDtos
{
    public class SystemUserLogBaseDto
    {
        public int Id { get; set; }
        public string SystemUserId { get; set; }
        public DateTime LogDate { get; set; }
        public string Log { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string TrxResult { get; set; }
        public string IPAdress { get; set; }
    }
}
