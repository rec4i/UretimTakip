using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class SorumluKullanıcı : BaseEntity
    {

        public int SorumluKullanıcıGrupId { get; set; }
        public SorumluKullanıcıGrup SorumluKullanıcıGrup { get; set; }

        public string UserId { get; set; }
        public AppIdentityUser User { get; set; }
    }
}
