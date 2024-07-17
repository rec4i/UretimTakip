using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.OtherEntities.BaseEntities
{
    public class LogBaseEntity : IEntity
    {
        public int Id { get; set; }
        public string SystemUserId { get; set; }
        public DateTime LogDate { get; set; }
        public string Log { get; set; }
        public bool IsDeleted { get; set; }
    }
}
