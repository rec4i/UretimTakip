using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2013.Excel;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.Cms;
using WebIU.Models.CariViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.ProgramViewModels;

namespace WebIU.Controllers
{
    public class CariController : Controller
    {

        private readonly ICariRepository _cariRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly ICariKoduTanımRepository _cariKoduTanımRepository;

        public CariController(ICariRepository cariRepository, IProgramŞirketGrupRepository programŞirketGrupRepository, UserManager<AppIdentityUser> userManager, ICariKoduTanımRepository cariKoduTanımRepository)
        {
            _cariRepository = cariRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _userManager = userManager;
            _cariKoduTanımRepository = cariKoduTanımRepository;
        }


        public IActionResult Cariler(int ParentId = 0)
        {
            return View(ParentId);
        }

        public async Task<IActionResult> CarilerPagination(int offset, int limit, string search, int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }


        public async Task<IActionResult> CariEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            if (userGroup == null)
            {
                return View("Error");
            }
            CariEditViewModel model = new CariEditViewModel();
            model.Cari = _cariRepository.Get(o => o.ProgramŞirketGrupId == userGroup && o.Id == Id);
            if (model.Cari == null)
            {
                return View("Error");
            }
            if (_cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup) == null)
            {
                return View("/Tanımlar/CariKoduTanım");
            }
            model.CariKodTanım = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup).Tanım;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CariEdit(int Id, string Ad, string Adres, string Kod)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            entity.CariKodu = Kod;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        [HttpGet]
        public async Task<IActionResult> CariAdd(int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            if (_cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup) == null)
            {
                return View("/Tanımlar/CariKoduTanım");
            }
            CariAddViewModel model = new CariAddViewModel();
            model.CariKodTanım = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup).Tanım;
            model.ParentId = ParentId;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CariAdd(string Ad, string Adres, string Kod, int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 0;
            entity.Adres = Adres;
            entity.CariKodu = Kod;
            entity.ParentId = ParentId;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Tedarikçiler()
        {


            return View();
        }

        [HttpGet("/Cari/TedarikçiAdd")]
        public IActionResult TedarikçiAdd()
        {
            return View();
        }

        public async Task<IActionResult> TedarikçiAdd(string Ad, string Adres)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 2;
            entity.Adres = Adres;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet("/Cari/TedarikçiEdit")]
        public async Task<IActionResult> TedarikçiEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            var entitiy = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);

            if (entitiy == null)
            {
                return View("/Error");
            }

            return View(entitiy);
        }


        public async Task<IActionResult> TedarikçiEdit(int Id, string Ad, string Adres)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> TedarikçiDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entity = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Belirtilen Uzantı Bulunamadı";
                return Json(res);
            }

            _cariRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);


        }


        public async Task<IActionResult> TedarikçilerPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }



        public async Task<IActionResult> Müşteriler()
        {

            return View();
        }


        public async Task<IActionResult> MüşteriDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entity = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Belirtilen Uzantı Bulunamadı";
                return Json(res);
            }

            _cariRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);


        }

        public async Task<IActionResult> MüşterilerPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }
        [HttpGet("/Cari/MüşteriAdd")]
        public IActionResult MüşteriAdd()
        {
            return View();
        }


        public async Task<IActionResult> MüşteriAdd(string Ad, string Adres)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 1;
            entity.Adres = Adres;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet("/Cari/MüşteriEdit")]
        public async Task<IActionResult> MüşteriEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            var entitiy = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);

            if (entitiy == null)
            {
                return View("/Error");
            }

            return View(entitiy);
        }


        public async Task<IActionResult> MüşteriEdit(int Id, string Ad, string Adres)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


    }
}
