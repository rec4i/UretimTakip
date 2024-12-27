using DataAccess.Abstract;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using WebIU.Models.HelperModels;
using WebIU.Models.ReçeteViewModels;
using WebIU.Models.SorumluKullanıcıViewModels;

namespace WebIU.Controllers
{
    public class SorumluKullanıcıController : Controller
    {

        private readonly ISorumluKullanıcıGrupRepository _sorumluKullanıcıGrupRepository;
        private readonly ISorumluKullanıcıRepository _sorumluKullanıcıRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        public SorumluKullanıcıController(ISorumluKullanıcıGrupRepository sorumluKullanıcıGrupRepository, ISorumluKullanıcıRepository sorumluKullanıcıRepository, UserManager<AppIdentityUser> userManager)
        {
            _sorumluKullanıcıGrupRepository = sorumluKullanıcıGrupRepository;
            _sorumluKullanıcıRepository = sorumluKullanıcıRepository;
            _userManager = userManager;
        }

        public IActionResult KullanıcıEkle(int GrupId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();

            var varmı = _sorumluKullanıcıRepository.GetAll(o => o.SorumluKullanıcıGrupId == GrupId && o.UserId == UserId);
            if (varmı.Count() >= 1)
            {
                res.status = 0;
                res.message = "Daha Önceden Eklenmiş";
                return Json(res);
            }



            SorumluKullanıcı entity = new SorumluKullanıcı();
            entity.UserId = UserId;
            entity.SorumluKullanıcıGrupId = GrupId;
            _sorumluKullanıcıRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult KullanıcıAra(string UserName)
        {
            var users = _userManager.Users.Where(o => o.UserName.Contains(UserName)).ToList();

            return Json(users);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GrupEkle(string GrupAdı)
        {
            JsonResponseModel res = new JsonResponseModel();
            SorumluKullanıcıGrup entitiy = new SorumluKullanıcıGrup();
            entitiy.GrupAdı = GrupAdı;
            _sorumluKullanıcıGrupRepository.Add(entitiy);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }

        public IActionResult KullanıcıSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _sorumluKullanıcıRepository.Get(o => o.Id == Id);
            _sorumluKullanıcıRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult GrupSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _sorumluKullanıcıGrupRepository.Get(o => o.Id == Id);
            _sorumluKullanıcıGrupRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult GrupKullanıcıları(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entities = _sorumluKullanıcıRepository.GetAllIncluded(o => o.SorumluKullanıcıGrupId == Id);

            res.data = entities;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult SorumluKullanıcıPaginaiton(int offset, int limit, string search, int GrupId)
        {
            SorumluKullanıcıPaginaitonModel model = new SorumluKullanıcıPaginaitonModel();
            model.rows = _sorumluKullanıcıRepository.GetAllIncludedPagination(o => o.SorumluKullanıcıGrupId == GrupId, offset.ToString(), limit.ToString(), search);
            model.total = _sorumluKullanıcıRepository.GetAllIncludedPaginationCount(o => o.SorumluKullanıcıGrupId == GrupId, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _sorumluKullanıcıRepository.GetAllIncludedPaginationCount(o => o.SorumluKullanıcıGrupId == GrupId, offset.ToString(), limit.ToString(), search);
            return Json(model);

        }

        public IActionResult SorumluKullanıcıGrupPaginaiton(int offset, int limit, string search, int ReçeteId)
        {
            SorumluKullanıcıGrupPaginaitonModel model = new SorumluKullanıcıGrupPaginaitonModel();
            model.rows = _sorumluKullanıcıGrupRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _sorumluKullanıcıGrupRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _sorumluKullanıcıGrupRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);

        }
    }
}
