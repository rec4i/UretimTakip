using Business.Abstract.Services;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.Profile;

namespace WebIU.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            ProfileListViewModel model = new ProfileListViewModel();
            model.Profiles = _profileService.GetAll();
            return View(model);
        }
        public IActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProfile(string ProfileName)
        {
            Profile profile = new Profile();
            profile.ProfileName = ProfileName;
            profile.AddedDate = DateTime.Now;

            _profileService.Add(profile);

            ProfileListViewModel model = new ProfileListViewModel();
            model.Profiles = _profileService.GetAll();
            return View("Index", model);
        }


        [HttpGet]
        public IActionResult DeleteProfile(int Id)
        {
            _profileService.Delete(Id);
            ProfileListViewModel model = new ProfileListViewModel();
            model.Profiles = _profileService.GetAll();

            return View("Index", model);
        }

        public IActionResult EditProfile(int Id)
        {
            var res = _profileService.GetAll(o => o.Id == Id).FirstOrDefault();
            return View(res);
        }

        [HttpPost]
        public IActionResult EditProfile(Profile profile)
        {
            _profileService.Update(profile);
            ProfileListViewModel model = new ProfileListViewModel();
            model.Profiles = _profileService.GetAll();
            return View("Index", model);
        }

    }
}
