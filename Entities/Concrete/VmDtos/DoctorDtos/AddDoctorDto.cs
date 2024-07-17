using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.DoctorDtos
{
    public class AddDoctorDto : OtherEntitesBaseDto
    {
        public string Name { get; set; }
        public int BranchId { get; set; }
        public int UnitId { get; set; }
    }
}
