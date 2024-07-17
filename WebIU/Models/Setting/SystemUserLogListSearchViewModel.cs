using Entities.Concrete.VmDtos.SettingDtos;
using Entities.Concrete.VmDtos.SystemUserLogDtos;

namespace WebIU.Models.Setting
{
    public class SystemUserLogListSearchViewModel
    {
        public List<SystemUserLogListDto>? SystemUserLogs { get; set; }
        public SystemUserLogListSearchDto Search { get; set; }
    }
}
