using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrete.Contants;
using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.SettingDtos;
using Entities.Concrete.VmDtos.SystemUserLogDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;

namespace Business.Concrete.Services
{
    public class SystemUserLogService : ISystemUserLogService
    {
        private readonly ISystemUserLogRepository _systemUserLogRepository;
        private readonly ICommonService _commonService;
        private string _currentUserId;
        public SystemUserLogService(
            ISystemUserLogRepository systemUserLogRepository,
            ICommonService commonService)
        {
            _systemUserLogRepository = systemUserLogRepository;
            _commonService = commonService;
            if (_commonService.IsAuthenticated())
                _currentUserId = _commonService.CurrnetUserId();
            else
                _currentUserId = "null";
        }
        public void Add(string log, string trxResult = "Success", string userId = "")
        {
            var controllerName = _commonService.ControllerName();
            var actionName = _commonService.ActionName();
            var ipAdress = _commonService.IPAdress();
            if (userId != "")
                _currentUserId = userId;

            var entity = new SystemUserLogAddDto
            {
                ActionName = actionName,
                ControllerName = controllerName,
                IPAdress = ipAdress,
                Log = log,
                TrxResult = trxResult,
                SystemUserId = _currentUserId
            };
            _systemUserLogRepository.Add(ObjectMapper.Mapper.Map<SystemUserLog>(entity));
        }

        public List<SystemUserLogListDto> GetAll()
        {
            var syestemLogList = ObjectMapper.Mapper.Map<List<SystemUserLogListDto>>(_systemUserLogRepository.GetAll()).OrderByDescending(p => p.LogDate).ToList();
            foreach (var syestemLog in syestemLogList)
                syestemLog.UserName = _commonService.GetUserName(syestemLog.SystemUserId);
            return syestemLogList;
        }

        public List<SystemUserLogListDto> GetAllByUserId(string userId)
        {
            var syestemLogList = ObjectMapper.Mapper.Map<List<SystemUserLogListDto>>(_systemUserLogRepository.GetAll(p => p.SystemUserId == userId)).OrderByDescending(p => p.LogDate).ToList();
            foreach (var syestemLog in syestemLogList)
                syestemLog.UserName = _commonService.GetUserName(syestemLog.SystemUserId);
            return syestemLogList;
        }

        public List<SystemUserLogListDto> SearchedSystemUserLogList(SystemUserLogListSearchDto search)
        {
            var systemUserLogs = _systemUserLogRepository.GetAll(p => p.IsDeleted == false).OrderByDescending(p => p.LogDate).ToList();
            var logDateStart = DateTime.ParseExact(search.LogDate.Split(" - ")[0], "MM/dd/yyyy", null);
            var logDateEnd = DateTime.ParseExact(search.LogDate.Split(" - ")[1], "MM/dd/yyyy", null);

            if (logDateStart != logDateEnd)
                systemUserLogs = systemUserLogs.Where(i => i.LogDate >= logDateStart && i.LogDate <= logDateEnd).ToList();
            if (search.Id != null)
                systemUserLogs = systemUserLogs.Where(i => i.Id.Equals(search.Id)).ToList();
            if (search.ActionName != null)
                systemUserLogs = systemUserLogs.Where(i => i.ActionName.ToLower().Contains(search.ActionName.ToLower().Trim())).ToList();
            if (search.ControllerName != null)
                systemUserLogs = systemUserLogs.Where(i => i.ControllerName.ToLower().Contains(search.ControllerName.ToLower().Trim())).ToList();
            if (search.IPAdress != null)
                systemUserLogs = systemUserLogs.Where(i => i.IPAdress.ToLower().Contains(search.IPAdress.ToLower().Trim())).ToList();
            if (search.Log != null)
                systemUserLogs = systemUserLogs.Where(i => i.Log.ToLower().Contains(search.Log.ToLower().Trim())).ToList();
            if (search.TrxResult != null)
                systemUserLogs = systemUserLogs.Where(i => i.TrxResult.ToLower().Contains(search.TrxResult.ToLower().Trim())).ToList();
            if (search.UserId != null)
                systemUserLogs = systemUserLogs.Where(i => i.SystemUserId.ToLower().Contains(search.UserId.ToLower().Trim())).ToList();

            SearchLogProcess(search, logDateStart, logDateEnd);
            return ObjectMapper.Mapper.Map<List<SystemUserLogListDto>>(systemUserLogs);
        }
        private void SearchLogProcess(SystemUserLogListSearchDto search, DateTime logDateStart, DateTime logDateEnd)
        {
            var logs = new List<string>();
            foreach (var item in search.GetType().GetProperties())
            {
                var value = search.GetType().GetProperty(item.Name).GetValue(search);
                if (value != null)
                {
                    if (item.Name == "LogDate")
                    {
                        if (logDateStart != logDateEnd)
                            logs.Add($"{item.Name} : {value}");
                    }
                    else
                    {
                        logs.Add($"{item.Name} : {value}");
                    }
                }
            }
            var stringLog = "";
            foreach (var item in logs)
                stringLog += item + ",";

            Add($"{stringLog} {LogMessage.SearchSystemUserLog}");
        }
    }
}
