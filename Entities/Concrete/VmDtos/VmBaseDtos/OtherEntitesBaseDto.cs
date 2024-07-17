using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmBaseDtos
{
    public class OtherEntitesBaseDto
    {
        public OtherEntitesBaseDto()
        {
            AddedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string? AddedUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
