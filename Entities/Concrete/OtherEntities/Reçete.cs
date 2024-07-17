using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Reçete : BaseEntity
    {
        public string ReçeteAdı { get; set; }
        public string Açıklama { get; set; }


        public List<Reçete_Stok_MTM> Reçete_Stok_MTMs { get; set; }
        public List<Reçete_Iş_MTM> Reçete_Iş_MTMs { get; set; }
    }
}
