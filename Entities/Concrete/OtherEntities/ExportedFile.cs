using Entities.Abstract;
using Entities.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities
{
    public class ExportedFile : BaseEntity
    {
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string FilePath { get; set; }
    }
}
