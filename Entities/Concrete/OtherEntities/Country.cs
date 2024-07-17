using Entities.Abstract;
using Entities.Concrete.BaseEntities;
using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class Country : BaseEntity
    {
      
        public string Name { get; set; }
        public int Row { get; set; }
        public string ShortName { get; set; }

    }
}
