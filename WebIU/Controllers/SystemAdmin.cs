using Business.Abstract.EmailService;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Concrete.Contants;
using Entities.Concrete.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.SystemAdminDtos;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.SystemAdmin;

namespace WebIU.Controllers
{
    [Authorize]
    public class SystemAdmin : Controller
    {
        private readonly IContactService _contactService;
        private readonly IEMailSenderService _emailSenderService;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly ICountryService _countryService;
        private readonly ISystemUserLogService _systemUserLogService;
        public SystemAdmin(
            IContactService contactService,
            IEMailSenderService emailSenderService,
            UserManager<AppIdentityUser> userManager,
            ICountryService countryService,
            ISystemUserLogService systemUserLogService)
        {
            _contactService = contactService;
            _emailSenderService = emailSenderService;
            _userManager = userManager;
            _countryService = countryService;
            _systemUserLogService = systemUserLogService;
        }
        [Authorize(Permission.SystemAdmin.Index)]
        public IActionResult Index()
        {
            _systemUserLogService.Add(LogMessage.SystemAdminIndex);
            return View();
        }
        [Authorize(Permission.SystemAdmin.ContactList)]
        public async Task<IActionResult> ContactList()
        {
            var contacsDtos = ObjectMapper.Mapper.Map<List<ContactDto>>(_contactService.GetAll());
            var usersResult = new List<ShortUserInfoDto>();
            foreach (var contacDto in contacsDtos)
            {
                var user = await _userManager.FindByIdAsync(contacDto.AddedUserId);
                usersResult.Add(new ShortUserInfoDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Image = user.Image,
                    Id = user.Id
                });
            }

            var model = new ContactListViewModel
            {
                ContactList = contacsDtos,
                Users = usersResult
            };
            _systemUserLogService.Add(LogMessage.ContactListPage);
            return View(model);
        }
        [Authorize(Permission.SystemAdmin.ContactInformation)]
        public async Task<IActionResult> ContactInformation(int Id)
        {
            var contactDto = ObjectMapper.Mapper.Map<ContactDto>(_contactService.GetById(Id));
            var userDto = ObjectMapper.Mapper.Map<ShortUserInfoDto>(await _userManager.FindByIdAsync(contactDto.AddedUserId));
            var model = new ContactInformationViewModel
            {
                Contact = contactDto,
                User = userDto
            };
            _systemUserLogService.Add($"{Id} {LogMessage.ContactInformationPage}");
            return View(model);
        }
        [Authorize(Permission.SystemAdmin.ContactDelete)]
        public IActionResult ContactDelete(int Id)
        {
            var contact = _contactService.GetById(Id);
            if (contact != null)
            {
                _contactService.Delete(contact);
                return Json("");
            }
            _systemUserLogService.Add($"{Id} {LogMessage.ContactDelete}");
            return Json(null);
        }

    }
}
