using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.SystemAdminDtos
{
    public class ContactDto : OtherEntitesBaseDto
    {
        public string SubjecTtype { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
