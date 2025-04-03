using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models;
using WebIU.Models.EkranTasarımViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.ReçeteViewModels;

namespace WebIU.Controllers
{
    public class EkranTasarımController : Controller
    {
        private readonly ISıcakSatışButonProfilRepository _sıcakSatışButonProfilRepository;
        private readonly ISıcakSatışHızlıButonRepository _sıcakSatışHızlıButonRepository;
        public EkranTasarımController(ISıcakSatışButonProfilRepository sıcakSatışButonProfilRepository, ISıcakSatışHızlıButonRepository sıcakSatışHızlıButonRepository)
        {
            _sıcakSatışButonProfilRepository = sıcakSatışButonProfilRepository;
            _sıcakSatışHızlıButonRepository = sıcakSatışHızlıButonRepository;
        }
        #region Button İşlemleri
        [HttpGet]

        public IActionResult ButtonEkle(int ProfilId, int ParentId = 0)
        {
            ButtonEkleViewModel model = new ButtonEkleViewModel();
            model.ParentId = ParentId;
            model.ProfilId = ProfilId;
            return View(model);

        }
        [HttpPost]
        public IActionResult ButtonEkle(string ButtonAdı, string ButtonRengi, int RivaStokId, int ParentId, int profilId, string StokAdı)
        {

            SıcakSatışHızlıButon entity = new SıcakSatışHızlıButon();
            entity.ButonAdı = ButtonAdı;
            entity.RivaStokId = RivaStokId;
            entity.ParentId = ParentId;
            entity.ButonRengi = ButtonRengi;
            entity.sıcakSatışButonProfilId = profilId;
            entity.StokAdı = StokAdı;
            _sıcakSatışHızlıButonRepository.Add(entity);
            if (ParentId != 0)
            {
                var eskiParent = _sıcakSatışHızlıButonRepository.Get(o => o.Id == ParentId);
                eskiParent.RivaStokId = null;
                _sıcakSatışHızlıButonRepository.Update(eskiParent);
            }
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }
        public IActionResult ButtonListesi(int Id, int ParentId)
        {
            ButtonListesiViewModel model = new ButtonListesiViewModel();
            var entity = _sıcakSatışButonProfilRepository.Get(o => o.Id == Id);
            model.Profil = entity;
            model.ParentId = ParentId;
            return View(model);
        }
        public IActionResult SıcakSatışHızlıButonPagination(int offset, int limit, string search, int ParentId, int Id = 0)
        {
            if (Id != 0)
            {
                GenericPaginaitonViewModel<SıcakSatışHızlıButon> model = new GenericPaginaitonViewModel<SıcakSatışHızlıButon>();
                model.rows = _sıcakSatışHızlıButonRepository.GetAllIncludedPagination(o => o.sıcakSatışButonProfilId == Id && o.ParentId == ParentId, null, offset.ToString(), limit.ToString(), search);
                model.total = _sıcakSatışHızlıButonRepository.GetAllIncludedPaginationCount(o => o.sıcakSatışButonProfilId == Id && o.ParentId == ParentId, offset.ToString(), limit.ToString(), search);
                model.totalNotFiltered = _sıcakSatışHızlıButonRepository.GetAllIncludedPaginationCount(o => o.sıcakSatışButonProfilId == Id && o.ParentId == ParentId, offset.ToString(), limit.ToString(), search);
                return Json(model);
            }
            else
            {
                GenericPaginaitonViewModel<SıcakSatışHızlıButon> model = new GenericPaginaitonViewModel<SıcakSatışHızlıButon>();
                model.rows = _sıcakSatışHızlıButonRepository.GetAllIncludedPagination(o => o.ParentId == ParentId, null, offset.ToString(), limit.ToString(), search);
                model.total = _sıcakSatışHızlıButonRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId, offset.ToString(), limit.ToString(), search);
                model.totalNotFiltered = _sıcakSatışHızlıButonRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId, offset.ToString(), limit.ToString(), search);
                return Json(model);
            }
        }

        public IActionResult ButonSil(int Id)
        {
            var entity = _sıcakSatışHızlıButonRepository.Get(o => o.Id == Id);
            _sıcakSatışHızlıButonRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        #endregion

        #region Profil İşlemleri
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProfilOluştur()
        {
            return View();
        }

        public IActionResult ProfilSil(int Id)
        {
            var entity = _sıcakSatışButonProfilRepository.Get(o => o.Id == Id);
            _sıcakSatışButonProfilRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpPost]
        public IActionResult ProfilOluştur(string ProfilAdı)
        {
            SıcakSatışButonProfil entity = new SıcakSatışButonProfil();
            entity.ProfilAdı = ProfilAdı;
            _sıcakSatışButonProfilRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        [HttpGet]
        public IActionResult ProfilDüzenle(int Id)
        {
            var entity = _sıcakSatışButonProfilRepository.Get(o => o.Id == Id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult ProfilDüzenle(int Id, string ProfilAdı)
        {
            var entity = _sıcakSatışButonProfilRepository.Get(o => o.Id == Id);
            entity.ProfilAdı = ProfilAdı;
            _sıcakSatışButonProfilRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult SıcakSatışButonProfilPagination(int offset, int limit, string search, int Id)
        {
            GenericPaginaitonViewModel<SıcakSatışButonProfil> model = new GenericPaginaitonViewModel<SıcakSatışButonProfil>();
            model.rows = _sıcakSatışButonProfilRepository.GetAllIncludedPagination(null, null, offset.ToString(), limit.ToString(), search);
            model.total = _sıcakSatışButonProfilRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _sıcakSatışButonProfilRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }
        #endregion

    }
}
