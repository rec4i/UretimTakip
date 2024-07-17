using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.ProductDtos
{
    public class AddProductDto
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int ISF { get; set; }
        public int DSF { get; set; }
        public int PSF { get; set; }
        public int KDVLI_PSF { get; set; }
        public string Photo { get; set; }
        public int MaxPharmacyOrder { get; set; }
    }
}
