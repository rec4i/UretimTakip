using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.AnnouncementUserDtos
{
    public class AddAnnouncementUserDto : OtherEntitesBaseDto
    {
        public int AnnouncementId { get; set; }
        public string UserId { get; set; }
    }
}
