using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.SettingDtos
{
    public class SystemUserLogListSearchDto
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? LogDate { get; set; }
        public string? Log { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? TrxResult { get; set; }
        public string? IPAdress { get; set; }
    }
}
