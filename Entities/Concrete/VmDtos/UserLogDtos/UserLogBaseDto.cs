using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UserLogDtos
{
    public class UserLogBaseDto
    {
        public int Id { get; set; }
        public string SystemUserId { get; set; }
        public DateTime LogDate { get; set; }
        public string Log { get; set; }
        public bool IsDeleted { get; set; }
        public string ChangeUserId { get; set; }

    }
}
