using Entities.Concrete.BaseEntities;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Ekipman : BaseEntity
    {
        public string EkipmanAdı { get; set; }


        public string ModelNumarasi { get; set; }
        public string Marka { get; set; }
        public DateTime UretimYili { get; set; }
        public DateTime SatınAlmaTarihi { get; set; }

    }
}
