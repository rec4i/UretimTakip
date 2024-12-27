using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using WebIU.Models.DepoViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.IşModels;

namespace WebIU.Controllers
{
    public class DepoController : Controller
    {
        private readonly IDepoRepository _depoRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly IDepoKoduTanımRepository _depoKoduTanımRepository;
        public DepoController(IDepoRepository depoRepository, IProgramŞirketGrupRepository programŞirketGrupRepository, IDepoKoduTanımRepository depoKoduTanımRepository)
        {
            _depoRepository = depoRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _depoKoduTanımRepository = depoKoduTanımRepository;
        }


        public async Task<IActionResult> Index()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            DepoIndexViewModel model = new DepoIndexViewModel();
            model.DepoKoduTanım = _depoKoduTanımRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup).FirstOrDefault().Tanım;
            return View(model);
        }

        public async Task<IActionResult> DepoEkle(string DepoAdı, string Adres, string DepoKodu)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            JsonResponseModel res = new JsonResponseModel();

            try
            {
                Depo entitiy = new Depo();
                entitiy.DepoAdı = DepoAdı;
                entitiy.DepoAdres = Adres;
                entitiy.DepoKodu = DepoKodu;
                entitiy.ProgramŞirketGrupId = userGroup;
                _depoRepository.Add(entitiy);
            }
            catch (Exception)
            {

                res.message = "Depo Eklenirken Bir Hata Oluştu";
                res.status = 0;
                return Json(res);
            }


            res.message = "İşlem Başarılı";
            res.status = 1;
            return Json(res);
        }
        public IActionResult DepoDüzenle(int Id, string DepoAdı, string Adres, string DepoKodu)
        {
            var entitiy = _depoRepository.Get(o => o.Id == Id);
            entitiy.DepoAdı = DepoAdı;
            entitiy.DepoAdres = Adres;
            entitiy.DepoKodu = DepoKodu;
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


        public async Task<IActionResult> DepoGetPagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            DepoPaginationModel model = new DepoPaginationModel();
            model.rows = _depoRepository.GetAllIncludedPagination(o => o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _depoRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _depoRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);

            return Json(model);
        }


    }
}
