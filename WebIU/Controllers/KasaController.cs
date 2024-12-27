using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.HelperModels;
using WebIU.Models.KasaViewModels;
using WebIU.Models.SeriNoViewModels;

namespace WebIU.Controllers
{
    public class KasaController : Controller
    {
        private readonly IKasaRepository _kasaRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly IKasaKoduTanımRepository _kasaKoduTanımRepository;
        public KasaController(IKasaRepository kasaRepository, IProgramŞirketGrupRepository programŞirketGrupRepository, IKasaKoduTanımRepository kasaKoduTanımRepository)
        {
            _kasaRepository = kasaRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _kasaKoduTanımRepository = kasaKoduTanımRepository;
        }
        public IActionResult Index(int? ParentId)
        {
            return View(ParentId);
        }
        public async Task<IActionResult> KasaAdd(int? ParentId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var kod = _kasaRepository.Get(o => o.Id == ParentId);
            KasaAddViewModel model = new KasaAddViewModel();
            model.ParentId = ParentId;
            model.ParentKod = kod == null ? null : kod.KasaKodu;
            model.Tanım = _kasaKoduTanımRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup).FirstOrDefault().Tanım;
            return View(model);
        }

        public IActionResult KasaDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _kasaRepository.Get(o => o.Id
            == Id);
            _kasaRepository.Delete(entity);

            res.status = 1;
            res.message = "İşlem başarılı";
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> KasaAdd(int ParentId, string KasaAdı, string KasaKodu, string Açıklama)
        {
            JsonResponseModel res = new JsonResponseModel();
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var varmı = _kasaRepository.GetAll(o => o.KasaKodu == KasaKodu && o.ProgramŞirketGrupId == userGroup);
            if (varmı.Count() >= 1)
            {
                res.status = 0;
                res.message = "Kasa Kodu Daha Önceden Kullanılmış Lütfen Farklı Bir KOD kullanın";
                return Json(res);
            }


            Kasa entity = new Kasa();
            entity.ProgramŞirketGrupId = userGroup;
            entity.ParentId = ParentId;
            entity.Açıklama = Açıklama;
            entity.KasaKodu = KasaKodu;
            entity.KasaAdı = KasaAdı;
            _kasaRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem başarılı";
            return Json(res);
        }
        public async Task<IActionResult> KasaPaginaiton(int offset, int limit, string search, int ParentId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            KasaPaginaitonViewModel model = new KasaPaginaitonViewModel();
            model.rows = _kasaRepository.GetAllIncludedPagination(o => o.ParentId == ParentId && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _kasaRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _kasaRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }
    }
}
