using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
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

        public ReçeteController(IReçeteRepository reçeteReposiyory, IStokRepository stokRepository, IIşRepository ışRepository, ITezgahRepository tezgahRepository, IReçete_Iş_MTMRepository reçete_Iş_MTMRepository)
        {
            _reçeteReposiyory = reçeteReposiyory;
            _stokRepository = stokRepository;
            _ışRepository = ışRepository;
            _tezgahRepository = tezgahRepository;
            _reçete_Iş_MTMRepository = reçete_Iş_MTMRepository;
        }
        public IActionResult Index()
        {
            ReçeteIndexViewModel model = new ReçeteIndexViewModel();
            model.Stoks = _stokRepository.GetAllIncluded();
            model.Işs = _ışRepository.GetAllIncluded();
            model.Tezgahs = _tezgahRepository.GetAllIncluded();

            return View(model);
        }

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


            var ct = 0;
            foreach (var item in IşsIds)
            {
                Reçete_Iş_MTM reçete_Iş_MTM = new Reçete_Iş_MTM();
                reçete_Iş_MTM.IşId = Convert.ToInt32(item);
                reçete_Iş_MTM.ReçeteId = addedEntitity.Id;

                reçete_Iş_MTM.İşAçıklama = Açıklamas[ct];

                reçete_Iş_MTM.KullanılacakDepoId = KullanılıcakDepoId[ct];
                reçete_Iş_MTM.KullanılacakStokId = KullanılacakStokId[ct];
                reçete_Iş_MTM.KullanılacakStokAdeti = KullanılacakStokAdeti[ct];

                reçete_Iş_MTM.UretilecekDepoId = HedefDepoId[ct];
                reçete_Iş_MTM.UretilecekStokId = HedefStokId[ct];
                reçete_Iş_MTM.UretilecekStokAdeti = HedefStokAdeti[ct];


                ct++;
                _reçete_Iş_MTMRepository.Add(reçete_Iş_MTM);
            }



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
