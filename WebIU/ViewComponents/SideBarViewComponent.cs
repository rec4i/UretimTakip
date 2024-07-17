using Business.Abstract.Services;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using WebIU.Models.ViewComponentModels;

namespace WebIU.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {

        private readonly ISideBarMenuItemService _sideBarMenuItemService;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SideBarViewComponent(
            ISideBarMenuItemService sideBarMenuItemService,
            UserManager<AppIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _sideBarMenuItemService = sideBarMenuItemService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public ViewViewComponentResult Invoke()
        {
            var userId = HttpContext.User.GetLoggedInUserId();
            var user = _userManager.FindByIdAsync(userId).Result;
            var userImage = user.Image;
            var userName = user.UserName;
            var lastLoginDate = user.LastLoginDate;
            var Url = HttpContext.Request.Path;
            var model = new SideBarMenuItemViewModel
            {
                MenuItems = _sideBarMenuItemService.GetAll(Url),
                UserName = userName,
                UserId = userId,
                UserImage = userImage,
                UserRoleName = RoleNames(user).Result,
                LastLoginDate = lastLoginDate
            };
            return View(model);
        }
        private async Task<string> RoleNames(AppIdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleName = "";
            for (int i = 0; i < userRoles.Count; i++)
            {
                roleName += userRoles[i] + " ";
            }
            return roleName;
        }
    }
}
