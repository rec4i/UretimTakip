using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.StokViewModels;

namespace WebIU.Controllers
{
    public class StokController : Controller
    {

        private readonly IStokRepository _stokRepository;
        private readonly IBirimRepository _birimRepository;
        public StokController(IStokRepository stokRepository, IBirimRepository birimRepository)
        {
            _stokRepository = stokRepository;
            _birimRepository = birimRepository;

        }

        public IActionResult Index()
        {
            StokIndexViewModel model = new StokIndexViewModel();
            model.Birims = _birimRepository.GetAll();
            return View(model);
        }


        public IActionResult GetStok(int Id)
        {
            var model = _stokRepository.GetAllIncluded(o => o.Id
            == Id);


            return Json(model);
        }


        public IActionResult StokKaydet(string StokAdı, int BirimId, string Açıklama, decimal StokAdeti)
        {

            Stok entity = new Stok();
            entity.StokAdı = StokAdı;
            entity.BirimId = BirimId;
            entity.Açıklama = Açıklama;
            entity.StokAdeti = StokAdeti;


            _stokRepository.Add(entity);


            return Json("İşlem Başarılı");
        }


        public IActionResult StokSil(int Id)
        {
            var entity = _stokRepository.Get(o => o.Id == Id);
            _stokRepository.Delete(entity);

            return Json("İşlem Başarılı");
        }

        public IActionResult StokDüzenle(int Id, string StokAdı, int BirimId, string Açıklama, decimal StokAdeti)
        {
            var entity = _stokRepository.Get(o => o.Id == Id);
            entity.StokAdı = StokAdı;
            entity.BirimId = BirimId;
            entity.Açıklama = Açıklama;
            entity.StokAdeti = StokAdeti;
            _stokRepository.Update(entity);


            return Json("İşlem Başarılı");
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
