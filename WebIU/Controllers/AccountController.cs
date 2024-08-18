using AutoMapper;
using Business.Abstract.EmailService;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrate.EmailService;
using Business.Concrete.Contants;
using Business.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tools.Concrete.HelperTools.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using WebIU.Models.Account;

namespace WebIU.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEMailSenderService _emailSenderService;
        private readonly ICultureService _cultureService;
        private readonly ICountryService _countryService;
        private readonly ISystemUserLogService _systemUserLogService;
        public AccountController(
           UserManager<AppIdentityUser> userManager,
           SignInManager<AppIdentityUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           IEMailSenderService emailSenderService,
           ICultureService cultureService,
           ICountryService countryService,
           ISystemUserLogService systemUserLogService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSenderService = emailSenderService;
            _cultureService = cultureService;
            _countryService = countryService;
            _systemUserLogService = systemUserLogService;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new UserLoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.IncorrectLogins, LogTrxResult.Fail);
                return View(userLoginViewModel);
            }
            if (userLoginViewModel.ReturnUrl == null)
                userLoginViewModel.ReturnUrl = "/";
            var user = await _userManager.FindByNameAsync(userLoginViewModel.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userLoginViewModel.UserName);
                if (user == null)
                {
                    TempData.Add("message", Messages.UserNotFound);
                    _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.UserNotFound, LogTrxResult.Fail);
                    return View(userLoginViewModel);
                }
            }
            if (user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
            }
            if (user.LockoutEnd != null)
            {
                TempData.Add("message", Messages.LockoutEnd);
                _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.LockoutEndUser, LogTrxResult.Fail);
                return RedirectToAction("Login", "Account", userLoginViewModel);
            }
            if (user.BanEnd < DateTime.Now)
            {
                user.BanEnd = null;
                user.BanComment = null;
                user.BanStart = null;
                user.BanStatus = false;
                await _userManager.UpdateAsync(user);
            }
            if (user.BanStatus)
            {
                TempData.Add("message", Messages.BannedUser);
                _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.BannedUserLogin, LogTrxResult.Fail);
                return RedirectToAction("Login", "Account", userLoginViewModel);
            }
            var result = _signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, true).Result;
            if (result.Succeeded)
            {
                _systemUserLogService.Add(LogMessage.Login, LogTrxResult.Success, user.Id);
                user.LastLoginDate = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return LocalRedirect(userLoginViewModel.ReturnUrl);
            }
            TempData.Add("message", Messages.UsernamePasswordIncorrect);
            _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.IncorrectLogins, LogTrxResult.Fail);
            return RedirectToAction("Login", "Account", userLoginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> LoginJson(string UserName, string Password, string ReturnUrl, bool RememberMe)
        {

            UserLoginViewModel userLoginViewModel = new UserLoginViewModel()
            {
                UserName = UserName,
                Password = Password,
                RememberMe = RememberMe,
                ReturnUrl = ReturnUrl
            };

            //if (!ModelState.IsValid)
            //{
            //    TempData.Add("message", Messages.WrongInformation);
            //    _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.IncorrectLogins, LogTrxResult.Fail);
            //    return Json("Veri İstenildiği Gibi Gönderlmedi");
            //}
            if (userLoginViewModel.ReturnUrl == null)
                userLoginViewModel.ReturnUrl = "/";
            var user = await _userManager.FindByNameAsync(userLoginViewModel.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(userLoginViewModel.UserName);
                if (user == null)
                {
                    TempData.Add("message", Messages.UserNotFound);
                    _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.UserNotFound, LogTrxResult.Fail);
                    return Json("Kullanıcı Bulunamadı");
                }
            }
            if (user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
            }
            if (user.LockoutEnd != null)
            {
                TempData.Add("message", Messages.LockoutEnd);
                _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.LockoutEndUser, LogTrxResult.Fail);
                return Json("Kullanıcı Belirli Bir Süre Yasaklı");
            }
            if (user.BanEnd < DateTime.Now)
            {
                user.BanEnd = null;
                user.BanComment = null;
                user.BanStart = null;
                user.BanStatus = false;
                await _userManager.UpdateAsync(user);
            }
            if (user.BanStatus)
            {
                TempData.Add("message", Messages.BannedUser);
                _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.BannedUserLogin, LogTrxResult.Fail);
                return Json("Kullanıcı Yasaklı");
            }
            var result = _signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, true).Result;
            if (result.Succeeded)
            {
                _systemUserLogService.Add(LogMessage.Login, LogTrxResult.Success, user.Id);
                user.LastLoginDate = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return Json("True/" + user.Id);
            }
            TempData.Add("message", Messages.UsernamePasswordIncorrect);
            _systemUserLogService.Add(userLoginViewModel.UserName + LogMessage.IncorrectLogins, LogTrxResult.Fail);
            return Json("Kullanıcı Adı Veya Şifre Yanlış");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _systemUserLogService.Add(LogMessage.Logout);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData.Add("message", Messages.InvalidMailAdress);
                return View(email);
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData.Add("message", Messages.UserNotFound);
                return View(email);
            }
            _systemUserLogService.Add(email + LogMessage.ForgotPassword);
            MailSended(user, email);
            return View();
        }
        private async void MailSended(AppIdentityUser user, string email)
        {
            var confirmedCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var urlAdress = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = confirmedCode });
            var mailSubject = "Confirmation Process of Nagis Informatics E-mail Address";
            var message = new Message(new string[] { email }, mailSubject, $"{Request.Scheme}://{Request.Host}{urlAdress}");
            _emailSenderService.SendEmailForgotPassword(message);
            TempData.Add("message", Messages.SendPasswordResetMail);
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            if (userId == null)
            {
                TempData.Add("message", Messages.UserNotFound);
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (code == null)
                code = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (userId != null)
            {
                var result = new ResetPasswordViewModel
                {
                    Code = code,
                    Email = user.Email,
                };
                _systemUserLogService.Add(LogMessage.ResetPassword);
                return View(result);
            }
            TempData.Add("message", Messages.UserNotFound);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {

            if (!ModelState.IsValid)
                return View(resetPasswordViewModel);

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    _systemUserLogService.Add(LogMessage.ResetPasswordCompleted);
                    return RedirectToAction("Login", "Account");
                }
            }
            _systemUserLogService.Add(LogMessage.ResetPasswordNotCompleted, LogTrxResult.Fail);
            return View(resetPasswordViewModel);
        }

        public IActionResult AccountInformation(string outsideUserId = null)
        {
            _systemUserLogService.Add(outsideUserId + LogMessage.AccountInformationSeen);
            ViewBag.OutsideUserId = outsideUserId;
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            _systemUserLogService.Add(LogMessage.ChangePasswordStart);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(changePasswordViewModel);
            }

            var userId = HttpContext.User.GetLoggedInUserId();
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);

            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{user.Id} {LogMessage.ChangePasswordEnd}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("AccountInformation", "Account");
            }
            _systemUserLogService.Add(LogMessage.ChangePasswordError, LogTrxResult.Fail);
            TempData.Add("message", Messages.WrongInformation);
            AddModalStateErrors(result);
            return View(changePasswordViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeMyAccountInformation()
        {
            string userId = HttpContext.User.GetLoggedInUserId();
            var user = await _userManager.FindByIdAsync(userId);
            var userDto = ObjectMapper.Mapper.Map<EditUserDto>(user);
            var model = new ChangeMyAccountInformationViewModel
            {
                User = userDto,
                Cultures = _cultureService.GetAll(),
                Countries = _countryService.GetAll()
            };
            _systemUserLogService.Add(LogMessage.ChangeMyAccountInformationStart);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeMyAccountInformation(ChangeMyAccountInformationViewModel changeMyAccountInformationViewModel)
        {
            var userId = HttpContext.User.GetLoggedInUserId();
            var user = await _userManager.FindByIdAsync(userId);
            changeMyAccountInformationViewModel.User.Image = user.Image;
            changeMyAccountInformationViewModel.Countries = _countryService.GetAll();
            changeMyAccountInformationViewModel.Cultures = _cultureService.GetAll();

            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(changeMyAccountInformationViewModel);
            }
            if (HasAdded(user, changeMyAccountInformationViewModel))
                return View(changeMyAccountInformationViewModel);

            if (changeMyAccountInformationViewModel.ImageFile != null)
            {
                changeMyAccountInformationViewModel.User.Image = await PhotoHelper.UpdatePhoto(changeMyAccountInformationViewModel.ImageFile, "UserImages");
                _systemUserLogService.Add($"{LogMessage.ChangePhoto} Eski Fotoğraf:{user.Image}, Yeni Fotoğraf:{changeMyAccountInformationViewModel.User.Image}");
                PhotoHelper.DeletePhoto(user.Image, "UserImages");
            }
            var userResult = ObjectMapper.Mapper.Map(changeMyAccountInformationViewModel.User, user);
            userResult.UpdatedUserId = HttpContext.User.GetLoggedInUserId();
            var result = await _userManager.UpdateAsync(userResult);

            if (result.Succeeded)
            {
                _systemUserLogService.Add($"{user.Id} {LogMessage.ChangeMyAccountInformationEnd}");
                TempData.Add("swalMessage", Messages.Successful);
                return RedirectToAction("AccountInformation", "Account");
            }

            AddModalStateErrors(result);
            _systemUserLogService.Add(LogMessage.ChangeMyAccountInformationError, LogTrxResult.Fail);
            return View(changeMyAccountInformationViewModel);
        }

        private bool HasAdded(AppIdentityUser user, ChangeMyAccountInformationViewModel changeMyAccountInformationViewModel)
        {
            if (user.UserName != changeMyAccountInformationViewModel.User.UserName)
            {
                var registeredUser = _userManager.FindByNameAsync(changeMyAccountInformationViewModel.User.UserName).Result;
                if (registeredUser != null)
                {
                    TempData.Add("message", Messages.UserNameUsed);
                    return true;
                }
            }
            if (user.Email != changeMyAccountInformationViewModel.User.Email)
            {
                var registeredEmail = _userManager.FindByEmailAsync(changeMyAccountInformationViewModel.User.Email).Result;
                if (registeredEmail != null)
                {
                    TempData.Add("message", Messages.EmailUsed);
                    return true;
                }
            }
            return false;
        }
        private void AddModalStateErrors(IdentityResult result)
        {
            if (result.Errors.ToList().Count > 0 && TempData["message"] == null)
                TempData["message"] = " ";
            result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
        }
    }
}
