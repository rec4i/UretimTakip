using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using WebIU.Models.StokViewModels;
using WebIU.Models.TezgahModels;
using WebIU.Models.TezgahViewModels;

namespace WebIU.Controllers
{
    public class TezgahController : Controller
    {


        private readonly ITezgahRepository _tezgahRepository;
        private readonly IIşRepository _ışRepository;
        private readonly IİşEmriRepository _işEmriRepository;
        private readonly IReçeteRepository _reçeteRepository;
        private readonly IReçete_Iş_MTMRepository _reçete_Iş_MTMRepository;
        private readonly ITezgah_Iş_MTMReposiyory _tezgah_Iş_MTMReposiyory;

        public TezgahController(ITezgahRepository tezgahRepository, IIşRepository ışRepository, IİşEmriRepository işEmriRepository, IReçeteRepository reçeteRepository, ITezgah_Iş_MTMReposiyory tezgah_Iş_MTMReposiyory, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository)
        {
            _tezgahRepository = tezgahRepository;
            _ışRepository = ışRepository;
            _işEmriRepository = işEmriRepository;
            _reçeteRepository = reçeteRepository;
            _tezgah_Iş_MTMReposiyory = tezgah_Iş_MTMReposiyory;
            _reçete_Iş_MTMRepository = reçete_Iş_MTMRepository;
        }

        public IActionResult Index()
        {
            TezgahIndexViewModel model = new TezgahIndexViewModel();
            model.Işs = _ışRepository.GetAll();

            return View(model);
        }
        public IActionResult TezgahEkle(string TezgahAdı, string Açıklama, List<string> IşsIds)
        {
            Tezgah entity = new Tezgah();
            entity.TezgahAdı = TezgahAdı;
            entity.Açıklama = Açıklama;

            entity.Guid = Guid.NewGuid().ToString();

            var addedEntity = _tezgahRepository.Add(entity);



            foreach (var item in IşsIds)
            {
                Tezgah_Iş_MTM entityy = new Tezgah_Iş_MTM();
                entityy.IşId = Convert.ToInt32(item);
                entityy.TezgahId = addedEntity.Id;

                _tezgah_Iş_MTMReposiyory.Add(entityy);
            }


            return Json("İşlem Başarılı");
        }
        public IActionResult GetTezgah(int Id)
        {
            var entitiy = _tezgahRepository.GetAllIncluded(o => o.Id == Id);
            return Json(entitiy);
        }
        public IActionResult TezgahSil(int Id)
        {
            var entitiy = _tezgahRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            _tezgahRepository.Delete(entitiy);
            return Json("İşlem Başarılı");
        }


        public IActionResult TezgahGetPagination(int offset, int limit, List<int> orderStatusId, string search)
        {

            TezgahPaginationModel model = new TezgahPaginationModel();
            model.rows = _tezgahRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _tezgahRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _tezgahRepository.GetAllIncludedPaginationCount();


            return Json(model);
        }




        public IActionResult TezgahtaYapılacakİşEmirleri(string qr)
        {
            var yapılanİşler = _tezgah_Iş_MTMReposiyory.GetAllIncluded(o => o.Tezgah.Guid == qr).Select(o => o.IşId);
            List<int?> yapılanİşlerIds = new List<int?>();
            foreach (var item in yapılanİşler)
            {
                yapılanİşlerIds.Add(item);
            }

            var hangiReçetedevar = _reçete_Iş_MTMRepository.GetAll(o => yapılanİşlerIds.Any(x => x == o.IşId)).Select(o => o.ReçeteId);
            var hangiİşEmirlerindeKullanılmuş = _işEmriRepository.GetAllIncluded(o => hangiReçetedevar.Any(x => x == o.ReçeteId));







            TezgahtaYapılacakİşEmirleriViewModel model = new TezgahtaYapılacakİşEmirleriViewModel();
            model.işEmris = hangiİşEmirlerindeKullanılmuş;

            return View(model);
        }

    }
}
