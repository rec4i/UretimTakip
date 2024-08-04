using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.CariViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.ŞantiyeViewModel;

namespace WebIU.Controllers
{
    public class ŞantiyeController : Controller
    {

        private readonly IŞantiyeRepository _şantiyeRepository;
        public ŞantiyeController(IŞantiyeRepository şantiyeRepository)
        {
            _şantiyeRepository = şantiyeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ŞantiyeBilgi(int Id)
        {
            ŞantiyeBilgiViewModel model = new ŞantiyeBilgiViewModel();
            model.Şantiye = _şantiyeRepository.Get(o => o.Id == Id);

            return View(model);
        }

        [HttpGet]
        public IActionResult BlokAdd(int Id)
        {

            return View(Id);
        }


        [HttpPost]
        public IActionResult BlokAdd(int kat, int stun, int derinlik, decimal Kalite, int ŞantiyeId, List<IFormFile> BlokGörüntüsü)
        {









            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json("");
        }




        public IActionResult ŞantiyePaginaiton(int offset, int limit, string search)
        {
            ŞantiyePaginationViewModel model = new ŞantiyePaginationViewModel();
            model.rows = _şantiyeRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _şantiyeRepository.GetAllIncludedPaginationCount(null);
            model.totalNotFiltered = _şantiyeRepository.GetAllIncludedPaginationCount(null);
            return Json(model);
        }



        [HttpGet]
        public IActionResult ŞantiyeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ŞantiyeAdd(string Adı, string Adres)
        {
            Şantiye entitiy = new Şantiye();
            entitiy.Adı = Adı;
            entitiy.Adres = Adres;
            _şantiyeRepository.Add(entitiy);



            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet]
        public IActionResult ŞantiyeEdit(int Id)
        {
            var entity = _şantiyeRepository.Get(o => o.Id == Id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult ŞantiyeEdit(int Id, string Adı, string Adres)
        {
            var entity = _şantiyeRepository.Get(o => o.Id == Id);
            entity.Adres = Adres;
            entity.Adı = Adı;

            _şantiyeRepository.Update(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult ŞantiyeDelete(int Id)
        {
            var entity = _şantiyeRepository.Get(o => o.Id == Id);
            _şantiyeRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
    }
}
