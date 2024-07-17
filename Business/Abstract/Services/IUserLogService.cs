using Entities.Concrete.VmDtos.UserLogDtos;

namespace Business.Abstract.Services
{
    public interface IUserLogService
    {
        List<UserLogListDto> GetAllByUserId(string userId);
        void Add(UserLogAddDto entity);
    }
}
