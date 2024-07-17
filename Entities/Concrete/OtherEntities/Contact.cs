using Entities.Abstract;
using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities.Concrete.OtherEntities
{
    public class Contact : BaseEntity
    {
        public string SubjecTtype  { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
