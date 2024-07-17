using Business.Abstract.Services;
using Entities.Concrete.VmDtos;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Options;
using WebIU.Models.ViewComponentModels;

namespace WebIU.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        private readonly ICultureService _cultureService;
        public NavbarViewComponent(
            ICultureService cultureService)
        {
            _cultureService = cultureService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new NavbarViewModel
            {
                Cultures= _cultureService.GetAll(),
               
            };
            return View(model);
        }
    }
}
