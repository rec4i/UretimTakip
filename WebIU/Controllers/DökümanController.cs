using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.DepoViewModels;
using WebIU.Models.DökümanModels;

namespace WebIU.Controllers
{
    public class DökümanController : Controller
    {

        private readonly IDökümanRepository _dökümanRepository;
        public DökümanController(IDökümanRepository dökümanRepository)
        {
            _dökümanRepository = dökümanRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DökümanPaginaton(int offset, int limit, List<int> orderStatusId, string search)
        {

            DökümanPaginationViewModel model = new DökümanPaginationViewModel();
            model.rows = _dökümanRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _dökümanRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _dökümanRepository.GetAllIncludedPaginationCount();

            return Json(model);


        }



    }
}
