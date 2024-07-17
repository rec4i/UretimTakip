using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UserDtos
{
    public class UserListDto : UserBaseDto
    {
        public DateTime? LastLoginDate { get; set; }
        public List<string> RoleNames { get; set; }
        public bool BanStatus { get; set; }
        public string CountryName { get; set; }
    }
}
