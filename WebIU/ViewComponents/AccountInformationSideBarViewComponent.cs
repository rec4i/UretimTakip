using AutoMapper;
using Business.Abstract.Services;
using Entities.Concrete.Identity;
using Entities.Concrete.VmDtos.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using WebIU.Models.ViewComponentModels;

namespace WebIU.ViewComponents
{
    public class AccountInformationSideBarViewComponent : ViewComponent
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ICultureService _cultureService;
        private readonly ICountryService _countryService;
        public AccountInformationSideBarViewComponent(
           UserManager<AppIdentityUser> userManager,
           IMapper mapper,
           ICultureService cultureService,
           ICountryService countryService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _cultureService = cultureService;
            _countryService = countryService;
        }
        public async Task<ViewViewComponentResult> InvokeAsync(string outsideUserId=null)
        {
            string userId = "";
            bool itself = true;
            if (string.IsNullOrEmpty(outsideUserId))
            {
                userId = HttpContext.User.GetLoggedInUserId();
                itself = true;
            }
            else
            {
                if (outsideUserId== HttpContext.User.GetLoggedInUserId())
                {
                    itself = true;
                    userId = HttpContext.User.GetLoggedInUserId();
                }
                else
                {
                    userId = outsideUserId;
                    itself = false;
                }  
            }
            var user = await _userManager.FindByIdAsync(userId);
            var roleList = (List<string>)_userManager.GetRolesAsync(_mapper.Map<AppIdentityUser>(user)).Result;
            var userDto = _mapper.Map<MyAccountDto>(user);

            var model = new MyAccountSideBarViewModel
            {
                User = userDto,
                Roles = roleList,
                CountryName = _countryService.GetById(user.CountryId).Name,
                Culture = _cultureService.GetCulture(user.CultureName),
                ItSelf=itself
            };
            return View(model);
        }
    }
}
