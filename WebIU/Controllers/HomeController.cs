using AutoMapper;
using Business.Abstract.EmailService;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrate.EmailService;
using Business.Concrete.Contants;
using Business.Contants;
using Entities.Concrete.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using WebIU.Models;
using WebIU.Models.Home;

namespace WebIU.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IEMailSenderService _emailSenderService;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IAnnouncementService _announcementService;
        private readonly ISystemUserLogService _systemUserLogService;
        public HomeController(
            IContactService contactService,
            IEMailSenderService emailSenderService,
            UserManager<AppIdentityUser> userManager,
            IAnnouncementService announcementService,
            ISystemUserLogService systemUserLogService)
        {
            _contactService = contactService;
            _emailSenderService = emailSenderService;
            _userManager = userManager;
            _systemUserLogService = systemUserLogService;
            _announcementService = announcementService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Permission.Home.Contact)]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Permission.Home.Contact)]
        public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(contactViewModel);
            }
            contactViewModel.Contact.AddedUserId = HttpContext.User.GetLoggedInUserId();
            var user = await _userManager.FindByIdAsync(contactViewModel.Contact.AddedUserId);

            var contact = ObjectMapper.Mapper.Map<Contact>(contactViewModel.Contact);
            if (contact != null)
            {
                _contactService.Add(contact);
                MailSended(user, contact);
                TempData.Add("swalMessage", Messages.Successful);
                return View();
            }
            _systemUserLogService.Add($"{LogMessage.Contact} Konu:{contact.Subject}");
            TempData.Add("message", Messages.Fail);
            return View(contactViewModel);
        }
        private void MailSended(AppIdentityUser user, Contact contact)
        {
            var mailContent = $"<b>{contact.Subject}</b> <br> {contact.Content}";
            var mailSubject = $"{user.UserName} {contact.SubjecTtype} Wrote To Us";
            var adminUsers = _userManager.GetUsersInRoleAsync("SystemAdmin").Result;
            foreach (var usr in adminUsers)
            {
                var message = new Message(new string[] { usr.Email }, mailSubject, mailContent);
                _emailSenderService.SendContact(message);
                _systemUserLogService.Add($"{LogMessage.MailSended} Kullanıcı:{usr.UserName} Konu:{contact.Subject}");
            }
        }
        public IActionResult Error()
        {
            _systemUserLogService.Add($"{LogMessage.ErrorPage}");
            return View();
        }
        [HttpGet]
        public IActionResult LanguageSelect(string url)
        {
            _systemUserLogService.Add($"{LogMessage.LanguageSelect}({url})");
            return LocalRedirect(url);
        }
        public IActionResult Accessdenied()
        {
            _systemUserLogService.Add($"{LogMessage.Accessdenied}");
            return View();
        }
        public IActionResult Page404()
        {
            _systemUserLogService.Add($"{LogMessage.Error404}");
            return View();
        }
        public IActionResult Page500()
        {
            _systemUserLogService.Add($"{LogMessage.Error500}");
            return View();
        }

        //[HttpGet]
        //public IActionResult TableWith_Announcments(FilterQueryStringModel filterQueryStringModel)
        //{
        //    AnnouncementViewModel model = new AnnouncementViewModel();

        //    model.rows = _announcementService.GetUserAnnouncments(filterQueryStringModel);
        //    model.total = _announcementService.GetUserAnnouncmentsCount(filterQueryStringModel);
        //    model.totalNotFiltered = _announcementService.GetUserAnnouncmentsCount();
        //    return new OkObjectResult(model);

        //}

    }
}