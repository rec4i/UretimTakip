using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UnitDtos
{
    public class EditUnitDto : OtherEntitesBaseDto
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int ServiceTypeId { get; set; }

    }
}
