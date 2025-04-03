using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
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
        private readonly IReçete_İş_MTM_DoldurlacakDökümanRepository _reçete_İş_MTM_DoldurlacakDökümanRepository;


        private readonly IStokHarektiRepository _stokHarektiRepository;

        private readonly IBelgeSoruRepository _belgeSoruRepository;


        public IşEmriController(IIşRepository ışRepository, IReçeteRepository reçeteRepository, IİşEmriRepository işEmriRepository, IUrunRepository urunRepository, IUrunAşamalarıRepository urunAşamalarıRepository, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository, IİşEmriDurumRepository işEmriDurumRepository, IReçete_Iş_MTM_KullanılacakStokRepository reçete_Iş_MTM_KullanılacakStokRepository, IReçete_Iş_MTM_ÜretilecekStokRepository reçete_Iş_MTM_ÜretilecekStokRepository, IStokRepository stokRepository, IReçete_İş_MTM_DoldurlacakDökümanRepository reçete_İş_MTM_DoldurlacakDöküman, IStokHarektiRepository stokHarektiRepository)
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
            _reçete_İş_MTM_DoldurlacakDökümanRepository = reçete_İş_MTM_DoldurlacakDöküman;

            _stokHarektiRepository = stokHarektiRepository;
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
                KullanılacakStokString += " " + (item.KullanılacakStokMiktarı) + " " + stok.Birim.BirimKodu + "</br>";

            }

            res.data = KullanılacakStokString;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }

        public IActionResult StokLotNoGetir(int StokId)
        {
            var stokHareketleri = _stokHarektiRepository.GetAll(o => o.StokId == StokId);
            List<string> lotNos = new List<string>();
            foreach (var _item in stokHareketleri.GroupBy(o => o.LotNo))
            {
                var LotNo = _item.FirstOrDefault().LotNo;
                decimal? miktar = 0M;
                foreach (var item in _item)
                {
                    //1 Depo Stok Girişi +
                    //2 Depo Stok Çıkışı -
                    //3 Fatura Alış +
                    //4 Fatura Satış - 
                    //5 Fatura İade -
                    //6 Üretim Stok Kullanımı - 
                    //7 Üretim Stok Üretimi +
                    if (item.HareketTipi == 1)
                    {
                        miktar = miktar + item.Adet;
                    }
                    else if (item.HareketTipi == 2)
                    {
                        miktar = miktar - item.Adet;
                    }
                    else if (item.HareketTipi == 3)
                    {
                        miktar = miktar + item.Adet;
                    }
                    else if (item.HareketTipi == 4)
                    {
                        miktar = miktar - item.Adet;
                    }
                    else if (item.HareketTipi == 5)
                    {
                        miktar = miktar - item.Adet;
                    }
                    else if (item.HareketTipi == 6)
                    {
                        miktar = miktar - item.Adet;
                    }
                    else if (item.HareketTipi == 7)
                    {
                        miktar = miktar - item.Adet;
                    }
                    else if (item.HareketTipi == 8)
                    {
                        miktar = miktar + item.Adet;
                    }
                }
                if (miktar > 0)
                {
                    lotNos.Add(LotNo);
                }
            }
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";

            res.data = lotNos;






            return Json(res);
        }


        public IActionResult İşEmriDüzenleStokHareketOluştur(int[] KullanılanStoklar, string[] KullanılanLotlar, decimal[] KullanılanStokMiktarları
            , int[] ÜretilecekStoklar, string[] ÜretilecekLotlar, decimal[] ÜretilenStokMiktarları
            , int İşEmriDurumId
            )
        {



            var eskiKullanılıcakStokHareket = _stokHarektiRepository.GetAll(o => o.İşEmriDurumId == İşEmriDurumId);
            foreach (var item in eskiKullanılıcakStokHareket)
                _stokHarektiRepository.Delete(item);




            var İşDurums = _işEmriDurumRepository.Get(o => o.Id == İşEmriDurumId);
            var işEmri = _işEmriRepository.Get(o => o.Id == İşDurums.İşEmriId);
            var reçeteMtms = _reçete_Iş_MTMRepository.Get(o => o.Id == İşDurums.Reçete_Iş_MTMId);




            JsonResponseModel res = new JsonResponseModel();
            for (int i = 0; i < KullanılanStoklar.Length; i++)
            {
                var kullanılacakStok = _reçete_Iş_MTM_KullanılacakStokRepository.GetAll(o => o.Reçete_Iş_MTMId == reçeteMtms.Id).Where(o => o.StokId == KullanılanStoklar[i]).FirstOrDefault();

                StokHareket stokHareket = new StokHareket();
                stokHareket.DepoId = kullanılacakStok.DepoId;
                stokHareket.İşEmriDurumId = İşEmriDurumId;
                stokHareket.Adet = KullanılanStokMiktarları[i];
                stokHareket.StokId = KullanılanStoklar[i];
                stokHareket.LotNo = KullanılanLotlar[i];
                stokHareket.HareketTipi = 6;


                _stokHarektiRepository.Add(stokHareket);
            }

            for (int i = 0; i < ÜretilecekStoklar.Length; i++)
            {
                var üretilecekStok = _reçete_Iş_MTM_ÜretilecekStokRepository.GetAll(o => o.Reçete_Iş_MTMId == reçeteMtms.Id).Where(o => o.StokId == KullanılanStoklar[i]).FirstOrDefault();

                StokHareket stokHareket = new StokHareket();
                stokHareket.DepoId = üretilecekStok.DepoId;
                stokHareket.İşEmriDurumId = İşEmriDurumId;
                stokHareket.Adet = ÜretilenStokMiktarları[i];
                stokHareket.StokId = ÜretilecekStoklar[i];
                stokHareket.LotNo = ÜretilecekLotlar[i];
                stokHareket.HareketTipi = 7;


                _stokHarektiRepository.Add(stokHareket);
            }



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
                KullanılacakStokString += " " + (item.ÜretilecekStokMiktarı) + " " + stok.Birim.BirimKodu + "</br>";

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

        public IActionResult İşEmriDurumDoldurulacakBelgeGetir(int işId)
        {
            var entity = _işEmriDurumRepository.Get(o => o.Id == işId);
            var dolduralacakBelgeler = _reçete_İş_MTM_DoldurlacakDökümanRepository.GetAllIncluded(o => o.Reçete_Iş_MTMId == entity.Reçete_Iş_MTMId, o => o.Include(x => x.Belge));
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.data = dolduralacakBelgeler;
            res.message = "İşlem Başarılı";
            return Json(res);


        }

        public IActionResult İşEmriDurumPaginaiton(int offset, int limit, string search, int İşEmriId)
        {
            İşEmriDurumViewModel model = new İşEmriDurumViewModel();
            model.rows = _işEmriDurumRepository.GetAllIncludedPagination(o => o.İşEmriId == İşEmriId, o => o.Include(x => x.Yapılacakİş).Include(x => x.İşEmri).Include(x => x.Reçete_Iş_MTM).Include(x => x.Reçete_Iş_MTM.Tezgah).Include(x => x.Reçete_Iş_MTM.Iş), offset.ToString(), limit.ToString(), search);
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


        public IActionResult GetBelgeSoruları(int BelgeId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var belgeSorular = _belgeSoruRepository.GetAll(o => o.BelgeId == BelgeId);





            res.status = 1;
            res.message = "İşlem Başarılı";

            res.data = belgeSorular;

            return Json(res);
        }
    }
}
