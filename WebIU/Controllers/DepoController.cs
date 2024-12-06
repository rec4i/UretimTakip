using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.DepoViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.IşModels;

namespace WebIU.Controllers
{
    public class DepoController : Controller
    {
        private readonly IDepoRepository _depoRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        public DepoController(IDepoRepository depoRepository, IProgramŞirketGrupRepository programŞirketGrupRepository)
        {
            _depoRepository = depoRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DepoEkle(string DepoAdı, string Adres)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Depo entitiy = new Depo();
            entitiy.DepoAdı = DepoAdı;
            entitiy.DepoAdres = Adres;
            entitiy.ProgramŞirketGrupId = userGroup;
            _depoRepository.Add(entitiy);


            JsonResponseModel res = new JsonResponseModel();
            res.message = "İşlem Başarılı";
            res.status = 1;
            return Json(res);
        }
        public IActionResult DepoDüzenle(int Id, string DepoAdı, string Adres)
        {
            var entitiy = _depoRepository.Get(o => o.Id == Id);
            entitiy.DepoAdı = DepoAdı;
            entitiy.DepoAdres = Adres;

            _depoRepository.Update(entitiy);


            JsonResponseModel res = new JsonResponseModel();
            res.message = "İşlem Başarılı";
            res.status = 1;
            return Json(res);
        }

        public IActionResult DepoSearchWithName(string DepoName)
        {
            var res = _depoRepository.GetAll(o => o.DepoAdı.Contains(DepoName));
            return Json(res);
        }

        public IActionResult DepoSil(int Id)
        {
            var entity = _depoRepository.Get(o => o.Id == Id);
            _depoRepository.Delete(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.message = "İşlem Başarılı";
            res.status = 1;
            return Json(res);
        }


        public IActionResult GetDepo(int Id)
        {
            var entitiy = _depoRepository.Get(o => o.Id
            == Id);

            return Json(entitiy);


        }


        public IActionResult DepoGetPagination(int offset, int limit, List<int> orderStatusId, string search)
        {

            DepoPaginationModel model = new DepoPaginationModel();
            model.rows = _depoRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _depoRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _depoRepository.GetAllIncludedPaginationCount();

            return Json(model);
        }


    }
}
