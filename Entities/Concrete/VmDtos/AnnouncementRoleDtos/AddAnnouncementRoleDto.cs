using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.AnnouncementRoleDtos
{
    public class AddAnnouncementRoleDto : OtherEntitesBaseDto
    {
        public int AnnouncementId { get; set; }
        public string Role { get; set; }
    }
}
