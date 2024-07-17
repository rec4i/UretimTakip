using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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
        public IşEmriController(IIşRepository ışRepository, IReçeteRepository reçeteRepository, IİşEmriRepository işEmriRepository, IUrunRepository urunRepository, IUrunAşamalarıRepository urunAşamalarıRepository, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository)
        {
            _ışRepository = ışRepository;
            _reçeteRepository = reçeteRepository;
            _urunRepository = urunRepository;
            _işEmriRepository = işEmriRepository;
            _urunAşamalarıRepository = urunAşamalarıRepository;
            _reçete_Iş_MTMRepository = reçete_Iş_MTMRepository;
        }

        public IActionResult Index()
        {
            IşEmriIndexViewModel model = new IşEmriIndexViewModel();
            model.Reçetes = _reçeteRepository.GetAll();
            return View(model);
        }



        public IActionResult IşEmriEkle(string Açıklama, string İşEmriAdı, int HedefAdet, int ReçeteId)
        {
            var reçete = _reçete_Iş_MTMRepository.GetAllIncluded(o => o.ReçeteId == ReçeteId);
            İşEmri entity = new İşEmri();
            entity.İşEmriAdı = İşEmriAdı;
            entity.Açıklama = Açıklama;
            entity.ReçeteId = ReçeteId;
            entity.HedefÜretim = HedefAdet;
            var addedEntity = _işEmriRepository.Add(entity);
            for (int i = 0; i < HedefAdet; i++)
            {
                Urun urun = new Urun();
                urun.İşEmriId = addedEntity.Id;
                var guid = Guid.NewGuid();
                urun.Guid = guid.ToString();
                var addedUrun = _urunRepository.Add(urun);

                foreach (var item in reçete)
                {
                    UrunAşamaları urunaşama = new UrunAşamaları();
                    urunaşama.UrunId = addedUrun.Id;
                    urunaşama.IşId = item.Iş.Id;
                    urunaşama.İşEmriId = addedEntity.Id;
                    _urunAşamalarıRepository.Add(urunaşama);

                }
            }
            return Json("İşlem Başarılı");
        }

        public IActionResult İşEmriSil(int Id)
        {
            var enttiy = _işEmriRepository.Get(o => o.Id == Id);
            _işEmriRepository.Delete(enttiy);
            return Json("İşlem Başarılı");
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
