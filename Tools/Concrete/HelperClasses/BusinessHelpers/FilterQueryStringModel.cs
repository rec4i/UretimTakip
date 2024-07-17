using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Concrete.HelperClasses.BusinessHelpers
{
    public class FilterQueryStringModel
    {
        public string Search { get; set; }
        public string Order { get; set; }
        public string Sort { get; set; }
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
