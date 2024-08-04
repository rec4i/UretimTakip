using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Araç : BaseEntity
    {
        public string AraçAdı { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int UretimYili { get; set; }
        public string Renk { get; set; }
        public string SaseNumarasi { get; set; }
        public string MotorNumarasi { get; set; }
        public DateTime TrafiğeÇıkışTarihi { get; set; }
    }
}
