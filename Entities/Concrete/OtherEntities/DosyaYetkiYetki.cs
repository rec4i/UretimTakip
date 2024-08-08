using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class DosyaYetkiYetki : BaseEntity
    {
        public string UserId { get; set; }
        public AppIdentityUser User { get; set; }


        public int DosyaId { get; set; }
        public Dosya Dosya { get; set; }

    }
}
