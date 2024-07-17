using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.PharmacyDtos
{
    public class ListPharmacyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GLN_NO { get; set; }
        public string Pharmacist_Name { get; set; }

    }
}
