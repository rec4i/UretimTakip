using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.CariViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.SeriNoViewModels;

namespace WebIU.Controllers
{
    public class SeriNoController : Controller
    {
        private readonly IFaturaSeriRepository _faturaSeriRepository;
        private readonly IÖdemeSeriRepository _ödemeSeriRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        public SeriNoController(IFaturaSeriRepository faturaSeriRepository, IÖdemeSeriRepository ödemeSeriRepository, IProgramŞirketGrupRepository programŞirketGrupRepository)
        {
            _faturaSeriRepository = faturaSeriRepository;
            _ödemeSeriRepository = ödemeSeriRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
        }

        public IActionResult FaturaSeriNoTanım()
        {
            return View();
        }
        public async Task<IActionResult> FaturaSeriNoTanımPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            FaturaSeriNoPaginationViewModel model = new FaturaSeriNoPaginationViewModel();
            model.rows = _faturaSeriRepository.GetAllIncludedPagination(o => o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _faturaSeriRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _faturaSeriRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }

        public async Task<IActionResult> FaturaSeniNoEkle(int SeriNoTürü, string SeriNo)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            JsonResponseModel res = new JsonResponseModel();
            FaturaSeri faturaSeri = new FaturaSeri();
            faturaSeri.ProgramŞirketGrupId = userGroup;
            faturaSeri.SeriTürü = SeriNoTürü;
            faturaSeri.SeriNo = SeriNo;
            _faturaSeriRepository.Add(faturaSeri);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> FaturaSeriNoSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _faturaSeriRepository.Get(o => o.Id == Id);
            _faturaSeriRepository.Delete(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult ÖdemeSeriNoTanım()
        {
            return View();
        }
        public async Task<IActionResult> ÖdemeSeriNoTanımPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            ÖdemeSeriNoPaginationViewModel model = new ÖdemeSeriNoPaginationViewModel();
            model.rows = _ödemeSeriRepository.GetAllIncludedPagination(o => o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _ödemeSeriRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _ödemeSeriRepository.GetAllIncludedPaginationCount(o => o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }

        public async Task<IActionResult> ÖdemeSeniNoEkle(int SeriNoTürü, string SeriNo)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            JsonResponseModel res = new JsonResponseModel();
            ÖdemeSeri faturaSeri = new ÖdemeSeri();
            faturaSeri.ProgramŞirketGrupId = userGroup;
            faturaSeri.SeriTürü = SeriNoTürü;
            faturaSeri.SeriNo = SeriNo;
            _ödemeSeriRepository.Add(faturaSeri);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> ÖdemeSeriNoSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _ödemeSeriRepository.Get(o => o.Id == Id);
            _ödemeSeriRepository.Delete(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
    }
}
