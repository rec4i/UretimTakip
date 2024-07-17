using AutoMapper;
using Business.Abstract.Services;
using Business.Concrate;
using Business.Contants;
using Entities.Concrete.Contants;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.AnnouncementDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using WebIU.Models.Announcement;

namespace WebIU.Controllers
{
    public class AnnouncementController : Controller
    {

        private readonly IAnnouncementService _announcementService;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AnnouncementController(IAnnouncementService announcement,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppIdentityUser> userManager)
        {
            _announcementService = announcement;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        [Authorize(Permission.Announcement.AnnouncementList)]
        public IActionResult AnnouncementList()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Permission.Announcement.AnnouncementList)]
        public IActionResult TableWith_AnnouncementList(FilterQueryStringModel filter)
        {
            AnnouncementViewModel model = new AnnouncementViewModel();

            model.rows = _announcementService.GetAll(filter);
            model.total = _announcementService.GellAllCount(filter);
            model.totalNotFiltered = _announcementService.GellAllCount();




            return new OkObjectResult(model);
        }

        [HttpGet]
        [Authorize(Permission.Announcement.AddAnnouncement)]
        public IActionResult AddAnnouncement()
        {
            AddAnnouncementViewModel model = new AddAnnouncementViewModel();
            model.announcement = new AddAnnouncementDto();

            model.announcement.ReleaseDate = DateTime.Now;
            model.announcement.AnnouncementUsersList = _userManager.Users.Select(o => o.UserName).ToList();
            model.announcement.AnnouncementRolesList = _roleManager.Roles.Select(o => o.Name).ToList();



            return View(model);
        }

        [HttpPost]
        [Authorize(Permission.Announcement.AddAnnouncement)]
        public IActionResult AddAnnouncement(AddAnnouncementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                return View(model);
            }

            _announcementService.Add(model.announcement);
            TempData.Add("swalMessage", Messages.Successful);
            return RedirectToAction("AnnouncementList");
        }


        [HttpGet]
        [Authorize(Permission.Announcement.UpdateAnnouncement)]
        public IActionResult UpdateAnnouncement(int Id)
        {


            var entity = _announcementService.Get(Id);

            if (entity is null)
            {
                return RedirectToAction("AnnouncementList");
            }

            UpdateAnnouncementViewModel model = new UpdateAnnouncementViewModel();
            model.announcement = new UpdateAnnouncementDto();

            model.announcement = ObjectMapper.Mapper.Map<UpdateAnnouncementDto>(entity);


            model.announcement.AnnouncementUsersList = _userManager.Users.Select(o => o.UserName).ToList();
            model.announcement.AnnouncementRolesList = _roleManager.Roles.Select(o => o.Name).ToList();



            return View(model);
        }



        [HttpPost]
        [Authorize(Permission.Announcement.UpdateAnnouncement)]
        public IActionResult UpdateAnnouncement(UpdateAnnouncementViewModel model)
        {

            if (!ModelState.IsValid)
            {
                TempData.Add("message", Messages.WrongInformation);
                model.announcement.AnnouncementUsersList = _userManager.Users.Select(o => o.UserName).ToList();
                model.announcement.AnnouncementRolesList = _roleManager.Roles.Select(o => o.Name).ToList();
                return View(model);
            }

            _announcementService.Update(model.announcement);
            TempData.Add("swalMessage", Messages.Successful);
            return RedirectToAction("AnnouncementList");

        }


        [HttpGet]
        [Authorize(Permission.Announcement.UpdateAnnouncement)]
        public IActionResult DeleteAnnouncement(int Id)
        {

            _announcementService.Remove(ObjectMapper.Mapper.Map<RemoveAnnouncementDto>(_announcementService.Get(Id)));
            TempData.Add("swalMessage", Messages.Successful);
            return RedirectToAction("AnnouncementList");

        }


        [HttpGet]
        [Authorize(Permission.Announcement.AnnouncementList)]
        public IActionResult AnnouncementContext(int Id)
        {
            var model = new AnnouncementPartialViewModel();
            model.Context = _announcementService.Get(Id).Context;
            return PartialView("_announcementContextPartial", model);

        }




    }
}
