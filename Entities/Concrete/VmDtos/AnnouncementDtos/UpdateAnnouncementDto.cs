using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.AnnouncementDtos
{
    public class UpdateAnnouncementDto : OtherEntitesBaseDto
    {
        public string Context { get; set; }
        public string? Type { get; set; }
        public string Subject { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<string>? AnnouncementRolesList { get; set; }
        public List<string>? AnnouncementUsersList { get; set; }


        public List<AnnouncementRole>? AnnouncementRoles { get; set; }
        public List<AnnouncementUser>? AnnouncementUsers { get; set; }
    }
}
