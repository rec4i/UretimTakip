using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class BlokBilgi : BaseEntity
    {

        public int StokId { get; set; }
        public Stok Stok { get; set; }
        public decimal Kalite { get; set; }



        public int Kat { get; set; }
        public int Stun { get; set; }
        public int Derinlik { get; set; }



        public int ŞantiyeId { get; set; }
        public Şantiye Şantiye { get; set; }



        public List<BlokGörüntü>? BlokGörüntüs { get; set; }
    }
}
