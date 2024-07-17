using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.PharmacyDtos
{
    public class AddPharmacyDto
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string GLN_NO { get; set; }
        public string? EMail { get; set; }
        public string? MediprofCode { get; set; }
        public string? District_500 { get; set; }
        public string Pharmacist_Name { get; set; }
    }
}
