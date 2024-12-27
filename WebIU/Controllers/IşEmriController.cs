using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using WebIU.Models.HelperModels;
using WebIU.Models.IşEmriViewModels;
using WebIU.Models.IşModels;
using WebIU.Models.ReçeteViewModels;

namespace WebIU.Controllers
{
    public class IşEmriController : Controller
    {
        private readonly IIşRepository _ışRepository;
        private readonly IReçeteRepository _reçeteRepository;
        private readonly IİşEmriRepository _işEmriRepository;
        private readonly IUrunRepository _urunRepository;
        private readonly IUrunAşamalarıRepository _urunAşamalarıRepository;
        private readonly IReçete_Iş_MTMRepository _reçete_Iş_MTMRepository;
        private readonly IİşEmriDurumRepository _işEmriDurumRepository;

        private readonly IReçete_Iş_MTM_KullanılacakStokRepository _reçete_Iş_MTM_KullanılacakStokRepository;
        private readonly IReçete_Iş_MTM_ÜretilecekStokRepository _reçete_Iş_MTM_ÜretilecekStokRepository;
        private readonly IStokRepository _stokRepository;

        public IşEmriController(IIşRepository ışRepository, IReçeteRepository reçeteRepository, IİşEmriRepository işEmriRepository, IUrunRepository urunRepository, IUrunAşamalarıRepository urunAşamalarıRepository, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository, IİşEmriDurumRepository işEmriDurumRepository, IReçete_Iş_MTM_KullanılacakStokRepository reçete_Iş_MTM_KullanılacakStokRepository, IReçete_Iş_MTM_ÜretilecekStokRepository reçete_Iş_MTM_ÜretilecekStokRepository, IStokRepository stokRepository)
        {
            _ışRepository = ışRepository;
            _reçeteRepository = reçeteRepository;
            _urunRepository = urunRepository;
            _işEmriRepository = işEmriRepository;
            _urunAşamalarıRepository = urunAşamalarıRepository;
            _reçete_Iş_MTMRepository = reçete_Iş_MTMRepository;
            _işEmriDurumRepository = işEmriDurumRepository;
            _reçete_Iş_MTM_KullanılacakStokRepository = reçete_Iş_MTM_KullanılacakStokRepository;
            _reçete_Iş_MTM_ÜretilecekStokRepository = reçete_Iş_MTM_ÜretilecekStokRepository;
            _stokRepository = stokRepository;
        }

        public IActionResult Index()
        {
            IşEmriIndexViewModel model = new IşEmriIndexViewModel();
            model.Reçetes = _reçeteRepository.GetAll();
            return View(model);
        }
        public IActionResult KullanılacakStokGetir(int işEmriDurumId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var İşDurums = _işEmriDurumRepository.Get(o => o.Id == işEmriDurumId);
            var işEmri = _işEmriRepository.Get(o => o.Id == İşDurums.İşEmriId);
            var reçeteMtms = _reçete_Iş_MTMRepository.Get(o => o.Id == İşDurums.Reçete_Iş_MTMId);

            var kullanılacakStok = _reçete_Iş_MTM_KullanılacakStokRepository.GetAll(o => o.Reçete_Iş_MTMId == reçeteMtms.Id);
            var KullanılacakStokString = "";
            foreach (var item in kullanılacakStok)
            {
                var stok = _stokRepository.GetAllIncluded(o => o.Id == item.StokId).FirstOrDefault();
                KullanılacakStokString += "-" + stok.StokAdı + "";
                KullanılacakStokString += " " + (item.KullanılacakStokMiktarı * işEmri.HedefÜretim) + " " + stok.Birim.BirimKodu + "</br>";

            }



            res.data = KullanılacakStokString;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }

        public IActionResult üretilecekStokGetir(int işEmriDurumId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var İşDurums = _işEmriDurumRepository.Get(o => o.Id == işEmriDurumId);
            var işEmri = _işEmriRepository.Get(o => o.Id == İşDurums.İşEmriId);
            var reçeteMtms = _reçete_Iş_MTMRepository.Get(o => o.Id == İşDurums.Reçete_Iş_MTMId);

            var kullanılacakStok = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAll(o => o.Reçete_Iş_MTMId == reçeteMtms.Id);
            var KullanılacakStokString = "";
            foreach (var item in kullanılacakStok)
            {
                var stok = _stokRepository.GetAllIncluded(o => o.Id == item.StokId).FirstOrDefault();
                KullanılacakStokString += "-" + stok.StokAdı + "";
                KullanılacakStokString += " " + (item.ÜretilecekStokMiktarı * işEmri.HedefÜretim) + " " + stok.Birim.BirimKodu + "</br>";

            }




            res.data = KullanılacakStokString;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }



        public IActionResult IşEmriEkle(string Açıklama, string İşEmriAdı, int HedefAdet, int ReçeteId, DateTime HedefBaşlamaTarihi, DateTime HedefBitişTarihi)
        {

            var reçete = _reçete_Iş_MTMRepository.GetAllIncluded(o => o.ReçeteId == ReçeteId);
            İşEmri entity = new İşEmri();
            entity.İşEmriAdı = İşEmriAdı;
            entity.Açıklama = Açıklama;
            entity.ReçeteId = ReçeteId;
            entity.HedefÜretim = HedefAdet;
            entity.HedefBaşlamaTarihi = HedefBaşlamaTarihi;
            entity.HedefBitişTarihi = HedefBitişTarihi;
            var addedEntity = _işEmriRepository.Add(entity);

            var yapılacakİşler = _reçete_Iş_MTMRepository.GetAll(o => o.ReçeteId == ReçeteId);

            foreach (var item in yapılacakİşler)
            {
                İşEmriDurum durum = new İşEmriDurum();
                durum.İşEmriId = addedEntity.Id;
                durum.YapılacakİşId = item.IşId;
                durum.TamamlanmaDurum = 1;
                durum.Reçete_Iş_MTMId = item.Id;

                _işEmriDurumRepository.Add(durum);
            }

            //for (int i = 0; i < HedefAdet; i++)
            //{
            //    Urun urun = new Urun();
            //    urun.İşEmriId = addedEntity.Id;
            //    var guid = Guid.NewGuid();
            //    urun.Guid = guid.ToString();
            //    var addedUrun = _urunRepository.Add(urun);

            //    foreach (var item in reçete)
            //    {
            //        UrunAşamaları urunaşama = new UrunAşamaları();
            //        urunaşama.UrunId = addedUrun.Id;
            //        urunaşama.IşId = item.Iş.Id;
            //        urunaşama.İşEmriId = addedEntity.Id;
            //        _urunAşamalarıRepository.Add(urunaşama);

            //    }
            //}
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }

        public IActionResult İşEmriSil(int Id)
        {
            var enttiy = _işEmriRepository.Get(o => o.Id == Id);
            _işEmriRepository.Delete(enttiy);
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult İşEmriDüzenle(int Id)
        {




            return View(Id);
        }

        public IActionResult İşEmriDurumPaginaiton(int offset, int limit, string search, int İşEmriId)
        {
            //var test = _işEmriDurumRepository.GetAllIncluded();
            İşEmriDurumViewModel model = new İşEmriDurumViewModel();
            model.rows = _işEmriDurumRepository.GetAllIncludedPagination(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);
            model.total = _işEmriDurumRepository.GetAllIncludedPaginationCount(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _işEmriDurumRepository.GetAllIncludedPaginationCount(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);

            return Json(model);
        }
        public IActionResult GetUrunPagination(int offset, int limit, string search, int İşEmriId)
        {
            UrunPagination model = new UrunPagination();
            model.rows = _urunRepository.GetAllIncludedPagination(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);
            model.total = _urunRepository.GetAllIncludedPaginationCount(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _urunRepository.GetAllIncludedPaginationCount(o => o.İşEmriId == İşEmriId, offset.ToString(), limit.ToString(), search);

            return Json(model);
        }
        public IActionResult GetIşEmriPagination(int offset, int limit, string search)
        {
            IşEmriPagination model = new IşEmriPagination();
            model.rows = _işEmriRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _işEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _işEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);

            return Json(model);
        }
    }
}
