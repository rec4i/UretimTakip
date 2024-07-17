using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Concrete.HelperTools.EntityHelpers
{
    [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Struct | System.AttributeTargets.Class)]
    public class TextSearchAttribute : Attribute
    {
        public string[]? SearchThisProperys { get; set; }
        public TextSearchAttribute()
        {

        }
        public TextSearchAttribute(string[] searchThisProperys)
        {
            SearchThisProperys = searchThisProperys;
        }
    }
}
