using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.ExportedFileDtos
{
    public class ListExportedFileDto : OtherEntitesBaseDto
    {
        public string FileName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FilePath { get; set; }
        public bool Status { get; set; }
    }
}
