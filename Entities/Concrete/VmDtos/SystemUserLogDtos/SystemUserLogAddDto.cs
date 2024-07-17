using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.SystemUserLogDtos
{
    public class SystemUserLogAddDto:SystemUserLogBaseDto
    {
        public SystemUserLogAddDto()
        {
            LogDate = DateTime.Now;
        }
    }
}
