using Entities.Concrete.Contants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace WebIU.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
