using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class ProgramŞirketKullanıcı : BaseEntity
    {

        public int ProgramŞirketGrupId { get; set; }
        public ProgramŞirketGrup ProgramŞirketGrup { get; set; }

        public string? UserId { get; set; }
        public AppIdentityUser? User { get; set; }
    }
}
