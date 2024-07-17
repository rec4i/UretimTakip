using Entities.Concrete.VmDtos.SettingDtos;
using Entities.Concrete.VmDtos.SystemUserLogDtos;

namespace Business.Abstract.Services
{
    public interface ISystemUserLogService
    {
        List<SystemUserLogListDto> GetAll();
        List<SystemUserLogListDto> GetAllByUserId(string userId);
        void Add(string log, string trxResult = "Success", string userId = "");
        List<SystemUserLogListDto> SearchedSystemUserLogList(SystemUserLogListSearchDto search);
    }
}
