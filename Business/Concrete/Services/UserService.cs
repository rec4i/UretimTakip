using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.Response;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        public UserService(UserManager<AppIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserDetailDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<UserDetailDto>.Fail(Messages.UserNotFound, 404);
            }

            return Response<UserDetailDto>.Success(ObjectMapper.Mapper.Map<UserDetailDto>(user), 200);
        }
    }
}
