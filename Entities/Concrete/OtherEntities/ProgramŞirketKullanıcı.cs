using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class ProgramŞirketKullanıcı
    {
        public string UserId { get; set; }
        public AppIdentityUser User { get; set; }
    }
}
