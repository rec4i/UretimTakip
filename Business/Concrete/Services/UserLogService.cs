using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.UserLogDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _userLogRepository;
        private readonly ICommonService _commonService;
        public UserLogService(
            IUserLogRepository userLogRepository,
            ICommonService commonService)
        {
            _userLogRepository = userLogRepository;
            _commonService = commonService;
        }

        public void Add(UserLogAddDto entity)
        {
            _userLogRepository.Add(ObjectMapper.Mapper.Map<UserLog>(entity));
        }

        public List<UserLogListDto> GetAllByUserId(string userId)
        {
            var userLogList = ObjectMapper.Mapper.Map<List<UserLogListDto>>(_userLogRepository.GetAll(p => p.ChangeUserId == userId)).OrderByDescending(p => p.LogDate).ToList();
            foreach (var userLog in userLogList)
                userLog.UserName = _commonService.GetUserName(userLog.SystemUserId);
            return userLogList;
        }
    }
}
