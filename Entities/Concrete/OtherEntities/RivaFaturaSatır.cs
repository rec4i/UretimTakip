using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class RivaFaturaSatır : BaseEntity
    {
        public int? RivaFaturaId { get; set; }
        public RivaFatura? RivaFatura { get; set; }

        public string? RivaFaturaSatırId { get; set; }

        public decimal GenelTutar { get; set; }
        public decimal birimFiyat { get; set; }
        public decimal iskonto { get; set; }
        public decimal kdv { get; set; }
        public decimal miktar { get; set; }
        public decimal ürünId { get; set; }
        public string ÜrünAdı { get; set; }
    }
}
