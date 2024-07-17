using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.OrderDetailDtos
{
    public class AddOrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }

        public int Piece { get; set; }

        public int ProductSurplus { get; set; }
    }
}
