using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class StokLotNo : BaseEntity
    {
        public string? LotNo { get; set; }
        public int? StokId { get; set; }
        public Stok? Stok { get; set; }
        public string? Açıklama { get; set; }
        public DateTime? SonKullanmaTarihi { get; set; }
        public decimal? Miktar { get; set; }
    }
}
