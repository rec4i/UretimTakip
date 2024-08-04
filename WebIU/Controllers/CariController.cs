using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.MSIdentity.Shared;
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

        public CariController(ICariRepository cariRepository, IProgramŞirketGrupRepository programŞirketGrupRepository, UserManager<AppIdentityUser> userManager)
        {
            _cariRepository = cariRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _userManager = userManager;
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


        public IActionResult TedarikçilerPaginaiton(int offset, int limit, string search)
        {
            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 2, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2);
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

        public IActionResult MüşterilerPaginaiton(int offset, int limit, string search)
        {
            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 1, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1);
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
