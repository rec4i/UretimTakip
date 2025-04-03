using System.Drawing.Printing;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using WebIU.Models;
using WebIU.Models.BelgeViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.KasaViewModels;

namespace WebIU.Controllers
{
    public class BelgeTasarımController : Controller
    {
        private readonly IBelgeRepository _belgeRepository;
        private readonly IBelgeSoruRepository _belgeSoruRepository;
        public BelgeTasarımController(IBelgeRepository belgeRepository, IBelgeSoruRepository belgeSoruRepository)
        {
            _belgeRepository = belgeRepository;
            _belgeSoruRepository = belgeSoruRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Belgeler()
        {
            return View();
        }

        public IActionResult SabitAlanSorusuOluştur(string SabitAlanYazısı, int BelgeId, string SabitAlanYazısıAçıklama)
        {
            JsonResponseModel res = new JsonResponseModel();

            BelgeSoru entity = new BelgeSoru();
            entity.BelgeId = BelgeId;
            //entity.SabitAlanYazısı = SabitAlanYazısı;
            entity.BelgeSoruTürü = 1;
            entity.Soru = SabitAlanYazısı;
            entity.Açıklama = SabitAlanYazısıAçıklama;
            _belgeSoruRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult EvetHayırSorusuOluştur(int BelgeId, string EvetHayırSorusu, string EvetHayırSorusuAçıklama)
        {
            JsonResponseModel res = new JsonResponseModel();
            BelgeSoru entity = new BelgeSoru();

            entity.BelgeId = BelgeId;
            //entity.SabitAlanYazısı = SabitAlanYazısı;
            entity.BelgeSoruTürü = 2;
            entity.Açıklama = EvetHayırSorusuAçıklama;
            entity.Soru = EvetHayırSorusu;
            _belgeSoruRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult BelgeDüzenle(int Id)
        {
            BelgeDüzenleViewModel model = new BelgeDüzenleViewModel();
            model.Belge = _belgeRepository.Get(o => o.Id == Id);
            return View(model);
        }
        public IActionResult GetBelgeWithName(string StokName)
        {
            var res = _belgeRepository.GetAll(o => o.BelgeAdı.Contains(StokName));
            return Json(res);
        }
     
        public async Task<IActionResult> BegleSoruPaginaiton(int offset, int limit, string search, int BelgeId)
        {
            GenericPaginaitonViewModel<BelgeSoru> model = new GenericPaginaitonViewModel<BelgeSoru>();

            model.rows = _belgeSoruRepository.GetAllIncludedPagination(o => o.BelgeId == BelgeId, null, offset.ToString(), limit.ToString(), search);
            model.total = _belgeSoruRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _belgeSoruRepository.GetAllIncludedPaginationCount();

            return Json(model);
        }

        public IActionResult BelgeEkle(string BelgeAdı)
        {
            JsonResponseModel res = new JsonResponseModel();
            Belge entity = new Belge();
            entity.BelgeAdı = BelgeAdı;
            _belgeRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }




        public async Task<IActionResult> BelgelerPaginaiton(int offset, int limit, string search, int ParentId)
        {
            GenericPaginaitonViewModel<Belge> model = new GenericPaginaitonViewModel<Belge>();

            model.rows = _belgeRepository.GetAllIncludedPagination(null, null, offset.ToString(), limit.ToString(), search);
            model.total = _belgeRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _belgeRepository.GetAllIncludedPaginationCount();

            return Json(model);
        }

    }
}
