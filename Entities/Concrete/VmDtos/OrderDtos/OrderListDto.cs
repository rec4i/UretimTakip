using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.OrderDtos
{
    public class ListOrderDto
    {
        public int Id { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public string PharmacyId { get; set; }
        public string UserId { get; set; }
    }
}
