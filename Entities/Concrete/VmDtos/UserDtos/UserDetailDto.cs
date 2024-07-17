using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UserDtos
{
    public class UserDetailDto : UserBaseDto
    {
        public DateTime? AddedDate { get; set; }
        public string? AddedUserId { get; set; }

        public DateTime? UpdateDate { get; set; }
        public string? UpdatedUserId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool BanStatus { get; set; }
        public DateTime? BanStart { get; set; }
        public DateTime? BanEnd { get; set; }
        public string? BanComment { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
