using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class AnnouncementRole : BaseEntity
    {

        public int AnnouncementId { get; set; }
        [ForeignKey("AnnouncementId")]
        public Announcement Announcement { get; set; }
        public string Role { get; set; }
    }
}
