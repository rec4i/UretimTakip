using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.Account
{
    public class MyAccountDto : UserBaseDto
    {
        public DateTime? AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? Image { get; set; }
    }
}
