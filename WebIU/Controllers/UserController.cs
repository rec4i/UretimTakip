using Business.Abstract.EmailService;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrate.EmailService;
using Business.Concrete.Contants;
using Business.Contants;
using Entities.Concrete.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.UserDtos;
using Entities.Concrete.VmDtos.UserLogDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Tools.Concrete.HelperTools.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using WebIU.Models.User;

namespace WebIU.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEMailSenderService _emailSenderService;
        private readonly ICountryService _countryService;
        private readonly ICultureService _cultureService;
        private readonly ISystemUserLogService _systemUserLogService;
        private readonly IUserLogService _userLogService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IProfileService _profileService;

        public UserController(
           UserManager<AppIdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IEMailSenderService emailSenderService,
           ICountryService countryService,
           ICultureService cultureService,
           ISystemUserLogService systemUserLogService,
           IUserLogService userLogService,
           IProfileService profileService,
           IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSenderService = emailSenderService;
            _countryService = countryService;
            _cultureService = cultureService;
            _systemUserLogService = systemUserLogService;
            _userLogService = userLogService;
            _authorizationService = authorizationService;
            _profileService = profileService;
        }

        [HttpGet]
        [Authorize(Permission.User.Search)]
        public async Task<IActionResult> Search()
        {

            var model = new SearchUserListViewModel
            {
                Countries = _countryService.GetAll(),
                Cultures = _cultureService.GetAll(),
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Permission.User.Search)]
        public IActionResult Search(SearchUserListViewModel model)
        {
            model.Countries = _countryService.GetAll();
            model.Cultures = _cultureService.GetAll();
            model.Users = SearchedUserList(model.Search);
            foreach (var user in model.Users)
                user.RoleNames = (List<string>)_userManager.GetRolesAsync(ObjectMapper.Mapper.Map<AppIdentityUser>(user)).Result;
            return View(model);
        }
        [HttpGet]
        [Authorize(Permission.User.UserInformation)]
        public async Task<IActionResult> UserInformation(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userDto = ObjectMapper.Mapper.Map<UserDetailDto>(user);

            userDto.RoleNames = (List<string>)_userManager.GetRolesAsync(user).Result;
            var updateUser = await _userManager.FindByIdAsync(user.UpdatedUserId);
            var addedUser = await _userManager.FindByIdAsync(user.AddedUserId);
            var updatetUserName = "";
            var addedUserName = "";
            if (updateUser != null)
                updatetUserName = updateUser.UserName;
            else
                updatetUserName = user.UpdatedUserId;

            if (addedUser != null)
                addedUserName = addedUser.UserName;
            else
                addedUserName = user.AddedUserId;

            var model = new UserInformationViewModel
            {
                User = userDto,
                AddedUserName = addedUserName,
                UpdatedUserName = updatetUserName,
                CountryName = _countryService.GetById(user.CountryId).Name,
                CultureName = _cultureService.GetCultureName(user.CultureName)
            };
            _systemUserLogService.Add($"{user.Id} ({user.UserName}) {LogMessage.UserInformation}");
            return View(model);
        }

        [HttpGet]
        [Authorize(Permission.User.EditUserInformation)]
        public async Task<IActionResult> EditUserInformation(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userDto = ObjectMapper.Mapper.Map<EditUserDto>(user);
            var userRolesNames = (List<string>)await _userManager.GetRolesAsync(user);

            var model = new EditUserInformationViewModel
            {
                User = userDto,
                Roles = AdminRoleList(),
                Cultures = _cultureService.GetAll(),
                Countries = _countryService.GetAll(),
                RoleNames = userRolesNames,
                Profiles = _profileService.GetAll(),
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Permission.User.EditUserInformation)]
        public async Task<IActionResult> EditUserInformation(EditUserInformationViewModel model)
        {

            var user = await _userManager.FindByIdAsync(model.User.Id);
            model.Roles = AdminRoleList();
            model.Countries = _countryService.GetAll();
            model.Cultures = _cultureService.GetAll();
            model.Profiles = _profileService.GetAll();
            if (model.User.Image == null)
                model.User.Image = user.Image;

            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(model);
            }
            if (user == null)
            {
                TempData.Add("message", Messages.UserNotFound);
                return View(model);
            }
            if (model.ImageFile != null)
            {
                model.User.Image = await PhotoHelper.UpdatePhoto(model.ImageFile, "UserImages");
                PhotoHelper.DeletePhoto(user.Image, "UserImages");
            }
            await UpdateUserLog(model.User, model.ImageFile); //User log detail
            var userResult = ObjectMapper.Mapper.Map(model.User, user);
            userResult.UpdatedUserId = HttpContext.User.GetLoggedInUserId();


            if (userResult.BanStatus)
                userResult.BanStart = DateTime.Now;
            else
            {
                userResult.BanStart = null;
                userResult.BanEnd = null;
                userResult.BanComment = null;
            }

            var result = await _userManager.UpdateAsync(userResult);
            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{user.Id} ({user.UserName}) {LogMessage.UserEdit}");//SystemUser Log
                var userRoles = _userManager.GetRolesAsync(userResult).Result;
                var exceptRoleAdd = model.RoleNames.Except(userRoles);
                var exceptRoleRemove = userRoles.Except(model.RoleNames);
                await _userManager.AddToRolesAsync(userResult, exceptRoleAdd);
                await _userManager.RemoveFromRolesAsync(userResult, exceptRoleRemove);
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("EditUserInformation", "User", new { userId = user.Id });
            }

            AddModalStateErrors(result);
            model.Profiles = _profileService.GetAll();
            return View(model);
        }
        [Authorize(Permission.User.UserDelete)]
        public async Task<IActionResult> UserDelete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                _systemUserLogService.Add($"{user.Id} ({user.UserName}) {LogMessage.UserEdit}");//SystemUser Log
                PhotoHelper.DeletePhoto(user.Image, "UserImages");
                user.IsDeleted = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Search", "User");
            }

            return RedirectToAction("Search", "User");
        }
        [HttpGet]
        [Authorize(Permission.User.AddUser)]
        public async Task<IActionResult> AddUser(int implementerId = 0)
        {


            ViewBag.Id = implementerId;
            var user = await _userManager.FindByIdAsync(HttpContext.User.GetLoggedInUserId());
            var userRoleList = await _userManager.GetRolesAsync(user);
            var implementerIds = new List<int>();

            bool isSuperAdmin = false;
            if (userRoleList.Any(p => p.Contains("SuperAdmin")))
                isSuperAdmin = true;

            var model = new AddUserViewModel
            {
                Cultures = _cultureService.GetAll(),
                Countries = _countryService.GetAll(),
                Roles = AdminRoleList(implementerId),
                ImplementerId = implementerId,
                IsSuperAdmin = isSuperAdmin,
       
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Permission.User.AddUser)]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            ViewBag.Id = model.ImplementerId;
            model.Cultures = _cultureService.GetAll();
            model.Countries = _countryService.GetAll();
            model.Roles = AdminRoleList();

            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(model);
            }

            if (model.ImageFile != null)
                model.User.Image = await PhotoHelper.UpdatePhoto(model.ImageFile, "UserImages");


            if (HasAdded(model.User.UserName, model.User.Email))
                return View(model);

            model.User.AddedUserId = HttpContext.User.GetLoggedInUserId();
            var user = ObjectMapper.Mapper.Map<AppIdentityUser>(model.User);
       

            if (string.IsNullOrEmpty(model.Password))
                model.Password = "RpcSystems977*";

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (model.MailSend)
                    MailSended(user, model.Password);
                await _userManager.AddToRolesAsync(user, model.RoleNames);
                _systemUserLogService.Add($"{user.Id} ({user.UserName}) {LogMessage.UserAdded}");//SystemUser Log
                foreach (var roleName in model.RoleNames)
                {
                    _systemUserLogService.Add($"{user.Id} ({user.UserName}) {roleName} {LogMessage.UserRoleAdded}");//SystemUser Log
                }
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("Search", "User");
            }

            AddModalStateErrors(result);
            return View(model);
        }
        private bool HasAdded(string userName, string email)
        {
            var registeredUser = _userManager.FindByNameAsync(userName).Result;
            if (registeredUser != null)
            {
                TempData.Add("message", Messages.UserNameUsed);
                return true;
            }
            var registeredEmail = _userManager.FindByEmailAsync(email).Result;
            if (registeredEmail != null)
            {
                TempData.Add("message", Messages.EmailUsed);
                return true;
            }
            return false;
        }
        private void MailSended(AppIdentityUser user, string password)
        {
            var mailContent = $"UserName:{user.UserName} <br> Password:{password} <br> EmailAdress:{user.Email}";
            var mailSubject = "Nagis Informatics membership information";
            var message = new Message(new string[] { user.Email }, mailSubject, mailContent);
            _emailSenderService.SendEmailRegister(message);
            _systemUserLogService.Add($"{user.Id} ({user.UserName}) {LogMessage.UserPasswordInformationMailSended}");//SystemUser Log
        }
        private void AddModalStateErrors(IdentityResult result)
        {
            if (result.Errors.ToList().Count > 0 && TempData["message"] == null)
                TempData["message"] = " ";

            result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
        }
        private List<IdentityRole> AdminRoleList(int implementerId = 0)
        {
            var user = _userManager.FindByIdAsync(HttpContext.User.GetLoggedInUserId()).Result;
            var userRoleList = _userManager.GetRolesAsync(user).Result;
            bool isSuperAdmin = false;
            if (userRoleList.Any(p => p.Contains("SuperAdmin")))
                isSuperAdmin = true;

            var roles = new List<IdentityRole>();
            roles = _roleManager.Roles.ToList();
            return roles;
        }
        private List<AppIdentityUser> UserList()
        {
            var currentUserId = HttpContext.User.GetLoggedInUserId();
            var user = _userManager.FindByIdAsync(currentUserId).Result;
            var userList = new List<AppIdentityUser>();
            if (_authorizationService.AuthorizeAsync(User, Permission.User.AllUserList).Result.Succeeded)
                userList = _userManager.Users.Where(p => !p.IsDeleted).ToList();
            return userList;
        }


        private List<UserListDto> SearchedUserList(UserSearchDto search)
        {
            var createDateStart = DateTime.ParseExact(search.AddedDate.Split(" - ")[0], "MM/dd/yyyy", null);
            var createDateEnd = DateTime.ParseExact(search.AddedDate.Split(" - ")[1], "MM/dd/yyyy", null);
            var loginDateStart = DateTime.ParseExact(search.LastLoginDate.Split(" - ")[0], "MM/dd/yyyy", null);
            var loginDateEnd = DateTime.ParseExact(search.LastLoginDate.Split(" - ")[1], "MM/dd/yyyy", null);

            var users = UserList();
            users = users.Where(p => p.Status.Equals(search.Status)).ToList();
            if (createDateStart != createDateEnd)
                users = users.Where(i => i.AddedDate >= createDateStart && i.AddedDate <= createDateEnd).ToList();
            if (loginDateStart != loginDateEnd)
                users = users.Where(i => i.LastLoginDate >= loginDateStart && i.LastLoginDate <= loginDateEnd).ToList();
            if (search.Id != null)
                users = users.Where(i => i.Id.Equals(search.Id)).ToList();
            if (search.UserName != null)
                users = users.Where(i => i.UserName.ToLower().Contains(search.UserName.ToLower().Trim())).ToList();
            if (search.Email != null)
                users = users.Where(i => i.Email.ToLower().Contains(search.Email.ToLower().Trim())).ToList();
            if (search.Job != null)
                users = users.Where(i => i.Job.ToLower().Contains(search.Job.ToLower().Trim())).ToList();
            if (search.BanStatus != null)
                users = users.Where(i => i.BanStatus.Equals(search.BanStatus)).ToList();
            if (search.CountryId != null)
                users = users.Where(i => i.CountryId.Equals(search.CountryId)).ToList();
            if (search.PhoneNumber != null)
                users = users.Where(i => i.PhoneNumber.ToLower().Contains(search.PhoneNumber.ToLower().Trim())).ToList();
            if (search.CultureName != null)
                users = users.Where(i => i.CultureName.ToLower().Contains(search.CultureName.ToLower().Trim())).ToList();
            SearchLogProcess(search, createDateStart, createDateEnd, loginDateStart, loginDateEnd);
            return ObjectMapper.Mapper.Map<List<UserListDto>>(users);
        }
        private void SearchLogProcess(UserSearchDto search, DateTime createDateStart, DateTime createDateEnd, DateTime loginDateStart, DateTime loginDateEnd)
        {
            var logs = new List<string>();
            foreach (var item in search.GetType().GetProperties())
            {
                var value = search.GetType().GetProperty(item.Name).GetValue(search);
                if (value != null)
                {
                    if (item.Name == "AddedDate")
                    {
                        if (createDateStart != createDateEnd)
                            logs.Add($"{item.Name} : {value}");
                    }
                    else if (item.Name == "LastLoginDate")
                    {
                        if (loginDateStart != loginDateEnd)
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

            _systemUserLogService.Add($"{stringLog} {LogMessage.SearchUser}");
        }
        private async Task UpdateUserLog(EditUserDto entity, IFormFile image)
        {
            var oldEntity = await _userManager.FindByIdAsync(entity.Id);
            var entityResult = ObjectMapper.Mapper.Map<AppIdentityUser>(entity);
            var logs = new List<string>();

            foreach (var item in oldEntity.GetType().GetProperties())
            {
                if (!(
                    item.Name == "AddedUserId" ||
                    item.Name == "UpdateUserId" ||
                    item.Name.Contains("Stamp") ||
                    item.Name.Contains("Normalized") ||
                    item.Name.Contains("Hash") ||
                    item.Name.Contains("EmailConfirmed") ||
                    item.Name.Contains("UpdatedUserId") ||
                    (item.Name == "Image" && image == null)))
                {
                    if (item.PropertyType == typeof(string) ||
                    item.PropertyType == typeof(int) ||
                    item.PropertyType == typeof(bool))
                    {
                        var oldValue = oldEntity.GetType().GetProperty(item.Name).GetValue(oldEntity);
                        if (oldValue == null)
                            oldValue = "null";

                        var newValue = entityResult.GetType().GetProperty(item.Name).GetValue(entityResult);
                        if (newValue == null)
                            newValue = "null";

                        if (!oldValue.Equals(newValue))
                            logs.Add($"{item.Name} : {oldValue} -> {newValue}");
                    }
                }
            }
            foreach (var log in logs)
            {
                _userLogService.Add(new UserLogAddDto
                {
                    Log = log,
                    SystemUserId = HttpContext.User.GetLoggedInUserId(),
                    ChangeUserId = entityResult.Id
                });
            }
        }
    }
}
