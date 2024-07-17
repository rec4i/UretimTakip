using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.PharmacyDtos
{
    public class UpdatePharmacyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string GLN_NO { get; set; }
        public string Mail { get; set; }
        public string MediprofCode { get; set; }
        public string District_500 { get; set; }
        public string Pharmacist_Name { get; set; }
    }
}
