using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks.Dataflow;
using WebIU.Models.HelperModels;
using WebIU.Models.ReçeteViewModels;

namespace WebIU.Controllers
{
    public class ReçeteController : Controller
    {

        private readonly IReçeteRepository _reçeteReposiyory;
        private readonly IStokRepository _stokRepository;
        private readonly IIşRepository _ışRepository;
        private readonly ITezgahRepository _tezgahRepository;
        private readonly IReçete_Iş_MTMRepository _reçete_Iş_MTMRepository;

        private readonly IReçete_Iş_MTM_KullanılacakStokRepository _reçete_Iş_MTM_KullanılacakStokRepository;
        private readonly IReçete_Iş_MTM_ÜretilecekStokRepository _reçete_Iş_MTM_ÜretilecekStokRepository;

        private readonly ISorumluKullanıcıGrupRepository _sorumluKullanıcıGrupRepository;


        public ReçeteController(IReçeteRepository reçeteReposiyory, IStokRepository stokRepository, IIşRepository ışRepository, ITezgahRepository tezgahRepository, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository, IReçete_Iş_MTM_KullanılacakStokRepository reçete_Iş_MTM_KullanılacakStokRepository, IReçete_Iş_MTM_ÜretilecekStokRepository reçete_Iş_MTM_ÜretilecekStokRepository, ISorumluKullanıcıGrupRepository sorumluKullanıcıGrupRepository)
        {
            _reçeteReposiyory = reçeteReposiyory;
            _stokRepository = stokRepository;
            _ışRepository = ışRepository;
            _tezgahRepository = tezgahRepository;
            _reçete_Iş_MTMRepository = reçete_Iş_MTMRepository;
            _reçete_Iş_MTM_KullanılacakStokRepository = reçete_Iş_MTM_KullanılacakStokRepository;
            _reçete_Iş_MTM_ÜretilecekStokRepository = reçete_Iş_MTM_ÜretilecekStokRepository;
            _sorumluKullanıcıGrupRepository = sorumluKullanıcıGrupRepository;
        }

        public IActionResult SorumluKullanıcıGrubuAra(string GrupAdı)
        {
            var entiites = _sorumluKullanıcıGrupRepository.GetAllIncluded(o => o.GrupAdı.Contains(GrupAdı));


            return Json(entiites);

        }


        public IActionResult ReçeteÜretilecekStokSil(int Id)
        {
            var entitiy = _reçete_Iş_MTM_ÜretilecekStokRepository.Get(o => o.Id == Id);
            JsonResponseModel res = new JsonResponseModel();
            _reçete_Iş_MTM_ÜretilecekStokRepository.Delete(entitiy);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }



        public IActionResult KullanılacakStokGetir(int MtmId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entites = _reçete_Iş_MTM_KullanılacakStokRepository.GetAllIncluded(o => o.Reçete_Iş_MTMId == MtmId);
            res.data = entites;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult ÜretilecekStokGetir(int MtmId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entites = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAllIncluded(o => o.Reçete_Iş_MTMId == MtmId);
            res.data = entites;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult ÜretilecekStokEkle(int StokId, int DepoId, decimal KullanılacakMiktar, int MtmId)
        {
            JsonResponseModel res = new JsonResponseModel();

            Reçete_Iş_MTM_ÜretilecekStok entity = new Reçete_Iş_MTM_ÜretilecekStok();
            entity.ÜretilecekStokMiktarı = KullanılacakMiktar;
            entity.StokId = StokId;
            entity.DepoId = DepoId;
            entity.Reçete_Iş_MTMId = MtmId;

            _reçete_Iş_MTM_ÜretilecekStokRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult ReçeteKullanılacakStokSil(int Id)
        {
            var entitiy = _reçete_Iş_MTM_KullanılacakStokRepository.Get(o => o.Id == Id);
            JsonResponseModel res = new JsonResponseModel();
            _reçete_Iş_MTM_KullanılacakStokRepository.Delete(entitiy);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult KullanılacakStokEkle(int StokId, int DepoId, decimal KullanılacakMiktar, int MtmId)
        {
            JsonResponseModel res = new JsonResponseModel();

            Reçete_Iş_MTM_KullanılacakStok entity = new Reçete_Iş_MTM_KullanılacakStok();
            entity.KullanılacakStokMiktarı = KullanılacakMiktar;
            entity.StokId = StokId;
            entity.DepoId = DepoId;
            entity.Reçete_Iş_MTMId = MtmId;

            _reçete_Iş_MTM_KullanılacakStokRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult Index()
        {
            ReçeteIndexViewModel model = new ReçeteIndexViewModel();
            model.Stoks = _stokRepository.GetAllIncluded();
            model.Işs = _ışRepository.GetAllIncluded();
            model.Tezgahs = _tezgahRepository.GetAllIncluded();

            return View(model);
        }
        [HttpGet]


        public IActionResult ReçeteDüzenle(int Id)
        {
            ReçeteDüzenleViewModel model = new ReçeteDüzenleViewModel();
            model.Reçete = _reçeteReposiyory.GetAll(o => o.Id == Id).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        public IActionResult ReçeteDüzenle(int Id, string ReçeteAdı, string Açıklama)
        {
            var entity = _reçeteReposiyory.Get(o => o.Id == Id);
            entity.Açıklama = Açıklama;
            entity.ReçeteAdı = ReçeteAdı;

            _reçeteReposiyory.Update(entity);



            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult ReçeteİşSil(int Id)
        {
            var entity = _reçete_Iş_MTMRepository.Get(o => o.Id == Id);
            _reçete_Iş_MTMRepository.Delete(entity);



            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult ReçeteİşEkle(int ReçeteId, int İşId, string Açıklama, int İşTamamlanmaSüresi, int SorumluGurpId)
        {
            Reçete_Iş_MTM entity = new Reçete_Iş_MTM();
            entity.IşId = İşId;
            entity.ReçeteId = ReçeteId;
            entity.İşAçıklama = Açıklama;
            entity.İşTamamlanmaSüresi = İşTamamlanmaSüresi;
            entity.SorumluKullanıcıGrupId = SorumluGurpId;

            _reçete_Iş_MTMRepository.Add(entity);



            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult Reçete_İş_Mtm_Paginaiton(int offset, int limit, string search, int ReçeteId)
        {
            Reçete_İş_Mtm_PaginaitonModel model = new Reçete_İş_Mtm_PaginaitonModel();
            model.rows = _reçete_Iş_MTMRepository.GetAllIncludedPagination(o => o.ReçeteId == ReçeteId, offset.ToString(), limit.ToString(), search);
            model.total = _reçete_Iş_MTMRepository.GetAllIncludedPaginationCount(o => o.ReçeteId == ReçeteId, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _reçete_Iş_MTMRepository.GetAllIncludedPaginationCount(o => o.ReçeteId == ReçeteId, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }


        public IActionResult Reçete_İş_Mtm_KullanıclacakStokPaginaiton(int offset, int limit, string search, int Id)
        {
            Reçete_İş_Mtm_KullanıclacakStokPaginaitonModel model = new Reçete_İş_Mtm_KullanıclacakStokPaginaitonModel();
            model.rows = _reçete_Iş_MTM_KullanılacakStokRepository.GetAllIncludedPagination(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            model.total = _reçete_Iş_MTM_KullanılacakStokRepository.GetAllIncludedPaginationCount(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _reçete_Iş_MTM_KullanılacakStokRepository.GetAllIncludedPaginationCount(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }

        public IActionResult Reçete_İş_Mtm_ÜretilecekStokPaginaiton(int offset, int limit, string search, int Id)
        {
            Reçete_İş_Mtm_ÜretilecekStokPaginaitonModel model = new Reçete_İş_Mtm_ÜretilecekStokPaginaitonModel();
            model.rows = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAllIncludedPagination(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            model.total = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAllIncludedPaginationCount(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAllIncludedPaginationCount(o => o.Reçete_Iş_MTMId == Id, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }
        //Reçete_İş_Mtm_KullanıclacakStokPaginaitonModel
        //Reçete_İş_Mtm_KullanıclacakStokPaginaiton



        public IActionResult GetReçetePagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            ReçetePaginatonModel model = new ReçetePaginatonModel();
            model.rows = _reçeteReposiyory.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);

            model.total = _reçeteReposiyory.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _reçeteReposiyory.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);

            return Json(model);
        }

        public IActionResult ReçeteAdd()
        {
            return View();
        }


        public IActionResult ReçeteEkle(string ReçeteAdı, string Açıklama, List<string> IşsIds, List<string> Açıklamas, List<int> KullanılıcakDepoId, List<int> KullanılacakStokId, List<decimal> KullanılacakStokAdeti, List<int> HedefDepoId, List<int> HedefStokId, List<decimal> HedefStokAdeti)
        {
            Reçete entity = new Reçete();
            entity.ReçeteAdı = ReçeteAdı;
            entity.Açıklama = Açıklama;
            var addedEntitity = _reçeteReposiyory.Add(entity);


            //var ct = 0;
            //foreach (var item in IşsIds)
            //{
            //    Reçete_Iş_MTM reçete_Iş_MTM = new Reçete_Iş_MTM();
            //    reçete_Iş_MTM.IşId = Convert.ToInt32(item);
            //    reçete_Iş_MTM.ReçeteId = addedEntitity.Id;

            //    reçete_Iş_MTM.İşAçıklama = Açıklamas[ct];

            //    reçete_Iş_MTM.KullanılacakDepoId = KullanılıcakDepoId[ct];
            //    reçete_Iş_MTM.KullanılacakStokId = KullanılacakStokId[ct];
            //    reçete_Iş_MTM.KullanılacakStokAdeti = KullanılacakStokAdeti[ct];

            //    reçete_Iş_MTM.UretilecekDepoId = HedefDepoId[ct];
            //    reçete_Iş_MTM.UretilecekStokId = HedefStokId[ct];
            //    reçete_Iş_MTM.UretilecekStokAdeti = HedefStokAdeti[ct];


            //    ct++;
            //    _reçete_Iş_MTMRepository.Add(reçete_Iş_MTM);
            //}



            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult ReleçeteSil(int Id)
        {
            var entity = _reçeteReposiyory.Get(o => o.Id == Id);
            _reçeteReposiyory.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
    }
}
