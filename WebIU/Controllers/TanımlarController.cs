using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.HelperModels;

namespace WebIU.Controllers
{
    public class TanımlarController : Controller
    {
        private readonly IStokKoduTanımRepository _stokKoduTanımRepository;
        private readonly ICariKoduTanımRepository _cariKoduTanımRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly UserManager<AppIdentityUser> _userManager;

        public TanımlarController(IProgramŞirketGrupRepository programŞirketGrupRepository, UserManager<AppIdentityUser> userManager, IStokKoduTanımRepository stokKoduTanımRepository, ICariKoduTanımRepository cariKoduTanımRepository)
        {
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _userManager = userManager;
            _stokKoduTanımRepository = stokKoduTanımRepository;
            _cariKoduTanımRepository = cariKoduTanımRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> StokKoduTanım()
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _stokKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            if (entntiy != null)
                return View(entntiy.Tanım);
            else
                return View("a");
        }

        [HttpPost]
        public async Task<IActionResult> StokKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _stokKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
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
            if (entntiy != null)
                return View(entntiy.Tanım);
            else
                return View("");
        }

        [HttpPost]
        public async Task<IActionResult> CariKoduTanımSave(string Kod)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entntiy = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            entntiy.Tanım = Kod;
            _cariKoduTanımRepository.Update(entntiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }



    }
}
