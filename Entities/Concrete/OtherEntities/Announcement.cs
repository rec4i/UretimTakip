using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Announcement : BaseEntity
    {
        public string Context { get; set; }
        public string? Type { get; set; }
        public string Subject { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<AnnouncementRole>? AnnouncementRoles { get; set; }
        public List<AnnouncementUser>? AnnouncementUsers { get; set; }
    }
}
