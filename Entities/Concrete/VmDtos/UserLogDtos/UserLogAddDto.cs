using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UserLogDtos
{
    public class UserLogAddDto: UserLogBaseDto
    {
        public UserLogAddDto()
        {
            LogDate = DateTime.Now;
        }
    }
}
