using Entities.Concrete.Response;
using Entities.Concrete.VmDtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IUserService
    {
        Task<Response<UserDetailDto>> GetUserByNameAsync(string userName);
    }
}
