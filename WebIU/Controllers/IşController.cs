using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using WebIU.Models.IşModels;
using WebIU.Models.TezgahViewModels;

namespace WebIU.Controllers
{
    public class IşController : Controller
    {
        private readonly IIşRepository _ışRepository;
        private readonly ITezgahRepository _tezgahRepository;


        public IşController(IIşRepository ışRepository, ITezgahRepository tezgahRepository)
        {
            _ışRepository = ışRepository;
            _tezgahRepository = tezgahRepository;

        }

        public IActionResult Index()
        {
            IşIndexViewModel model = new IşIndexViewModel();
            model.Tezgahs = _tezgahRepository.GetAllIncluded();
            return View(model);
        }

        public IActionResult GetIş(int Id)
        {
            var entitity = _ışRepository.GetAllIncluded(o => o.Id == Id);
            return Json(entitity);

        }

        public IActionResult IşSil(int Id)
        {
            var entity = _ışRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            _ışRepository.Delete(entity);

            return Json("İşlem Başarılı");

        }



        public IActionResult IşEkle(string IşAdı, string Açıklama)
        {
            Iş entitiy = new Iş();
            entitiy.IşAdı = IşAdı;
            entitiy.Açıklama = Açıklama;

            _ışRepository.Add(entitiy);


            return Json("İşlem Başarılı");
        }

        public IActionResult IşGetPagination(int offset, int limit, List<int> orderStatusId, string search)
        {

            IşPaginationModel model = new IşPaginationModel();
            model.rows = _ışRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _ışRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _ışRepository.GetAllIncludedPaginationCount();


            return Json(model);
        }

    }
}
