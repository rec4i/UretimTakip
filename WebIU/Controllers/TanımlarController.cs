using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.HelperModels;
using WebIU.Models.TanımlarViewModel;

namespace WebIU.Controllers
{
    public class TanımlarController : Controller
    {
        private readonly IStokKoduTanımRepository _stokKoduTanımRepository;
        private readonly ICariKoduTanımRepository _cariKoduTanımRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IDepoKoduTanımRepository _depoKoduTanımRepository;
        private readonly IKasaKoduTanımRepository _kasaKoduTanımRepository;

        public TanımlarController(IProgramŞirketGrupRepository programŞirketGrupRepository, UserManager<AppIdentityUser> userManager, IStokKoduTanımRepository stokKoduTanımRepository, ICariKoduTanımRepository cariKoduTanımRepository, IDepoKoduTanımRepository depoKoduTanımRepository, IKasaKoduTanımRepository kasaKoduTanımRepository)
        {
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _userManager = userManager;
            _stokKoduTanımRepository = stokKoduTanımRepository;
            _cariKoduTanımRepository = cariKoduTanımRepository;
            _depoKoduTanımRepository = depoKoduTanımRepository;
            _kasaKoduTanımRepository = kasaKoduTanımRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KasaKoduTanım()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _kasaKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            KasaKoduTanımViewModel model = new KasaKoduTanımViewModel();

            if (entntiy != null)
            {
                model.Tanım = entntiy.Tanım;
                return View(model);
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> KasaKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _kasaKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            if (entntiy == null)
            {
                entntiy = _kasaKoduTanımRepository.Add(new Entities.Concrete.OtherEntities.KasaKoduTanım
                {
                    Tanım = Kod,
                    ProgramŞirketGrupId = userGroup
                });
            }

            entntiy.Tanım = Kod;
            _kasaKoduTanımRepository.Update(entntiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> DepoKoduTanım()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _depoKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            DepoKoduTanımViewModel model = new DepoKoduTanımViewModel();

            if (entntiy != null)
            {
                model.Tanım = entntiy.Tanım;
                return View(model);
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> DepoKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _depoKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            if (entntiy == null)
            {
                entntiy = _depoKoduTanımRepository.Add(new Entities.Concrete.OtherEntities.DepoKoduTanım
                {
                    Tanım = Kod,
                    ProgramŞirketGrupId = userGroup
                });
            }

            entntiy.Tanım = Kod;
            _depoKoduTanımRepository.Update(entntiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet]
        public async Task<IActionResult> StokKoduTanım()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _stokKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            StokKoduTanımViewModel model = new StokKoduTanımViewModel();

            if (entntiy != null)
            {
                model.Tanım = entntiy.Tanım;
                return View(model);
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> StokKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _stokKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            if (entntiy == null)
            {
                entntiy = _stokKoduTanımRepository.Add(new Entities.Concrete.OtherEntities.StokKoduTanım
                {
                    Tanım = Kod,
                    ProgramŞirketGrupId = userGroup
                });
            }

            entntiy.Tanım = Kod;
            _stokKoduTanımRepository.Update(entntiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        [HttpGet]
        public async Task<IActionResult> CariKoduTanım()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            CariKoduTanımViewModel model = new CariKoduTanımViewModel();


            if (entntiy != null)
            {
                model.Tanım = entntiy.Tanım;
                return View(model);
            }
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> CariKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            if (entntiy == null)
            {
                entntiy = _cariKoduTanımRepository.Add(new Entities.Concrete.OtherEntities.CariKoduTanım
                {
                    Tanım = Kod,
                    ProgramŞirketGrupId = userGroup
                });
            }
            entntiy.Tanım = Kod;
            _cariKoduTanımRepository.Update(entntiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }



    }
}
