using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Şantiye : BaseEntity
    {
        public string Adı { get; set; }
        public string Adres { get; set; }

        public List<BlokBilgi> BlokBilgis { get; set; }
    }
}
