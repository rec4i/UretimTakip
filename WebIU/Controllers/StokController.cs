using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebIU.Models.HelperModels;
using WebIU.Models.StokViewModels;

namespace WebIU.Controllers
{
    public class StokController : Controller
    {

        private readonly IStokRepository _stokRepository;
        private readonly IBirimRepository _birimRepository;
        private readonly IDepoRepository _depoRepository;
        private readonly IStokHarektiRepository _stokHarektiRepository;

        public StokController(IStokRepository stokRepository, IBirimRepository birimRepository, IDepoRepository depoRepository, IStokHarektiRepository stokHarektiRepository)
        {
            _stokRepository = stokRepository;
            _birimRepository = birimRepository;
            _depoRepository = depoRepository;
            _stokHarektiRepository = stokHarektiRepository;
        }

        public IActionResult Index()
        {
            StokIndexViewModel model = new StokIndexViewModel();
            model.Birims = _birimRepository.GetAll();
            model.Depos = _depoRepository.GetAll();
            return View(model);
        }


        public IActionResult GetStok(int Id)
        {
            var model = _stokRepository.GetAllIncluded(o => o.Id
            == Id);

            return Json(model);
        }


        public IActionResult GetStokWithName(string StokName)
        {
            var res = _stokRepository.GetAll(o => o.StokAdı.Contains(StokName));
            return Json(res);

        }

        public IActionResult StokKaydet(string StokAdı, int BirimId, string Açıklama, decimal StokAdeti, int DepoId)
        {

            Stok entity = new Stok();
            entity.StokAdı = StokAdı;
            entity.BirimId = BirimId;
            entity.Açıklama = Açıklama;

            var addedEntity = _stokRepository.Add(entity);

            StokHareket stokHarekti = new StokHareket();
            stokHarekti.StokId = addedEntity.Id;
            stokHarekti.Adet = StokAdeti;
            stokHarekti.HareketTipi = 1;
            stokHarekti.DepoId = DepoId;
            _stokHarektiRepository.Add(stokHarekti);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult StokSil(int Id)
        {
            var entity = _stokRepository.Get(o => o.Id == Id);
            _stokRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult StokDüzenle(int Id, string StokAdı, int BirimId, string Açıklama, decimal StokAdeti, int DepoId)
        {
            var entity = _stokRepository.Get(o => o.Id == Id);
            entity.StokAdı = StokAdı;
            entity.BirimId = BirimId;
            entity.Açıklama = Açıklama;
            //entity.DepoId = DepoId;
            _stokRepository.Update(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult StokPagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            StokPaginatonModel model = new StokPaginatonModel();
            model.rows = _stokRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _stokRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _stokRepository.GetAllIncludedPaginationCount();


            return Json(model);
        }

    }
}
