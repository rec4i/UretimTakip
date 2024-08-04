using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using WebIU.Models.HelperModels;
using WebIU.Models.IşModels;
using WebIU.Models.ProgramViewModels;

namespace WebIU.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly IProgramŞirketKullanıcıRepository _programŞirketKullanıcıRepository;
        private readonly UserManager<AppIdentityUser> _userManager;


        public ProgramController(IProgramŞirketGrupRepository programŞirketGrupRepository, IProgramŞirketKullanıcıRepository programŞirketKullanıcıRepository, UserManager<AppIdentityUser> userManager)
        {
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _programŞirketKullanıcıRepository = programŞirketKullanıcıRepository;
            _userManager = userManager;
        }



        public IActionResult ProgramEdit(int Id)
        {
            var model = _programŞirketGrupRepository.Get(o => o.Id == Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult ProgramKullanıcıEdit(string Adı, string YetkiliİletişimNo, int Id, bool Aktifmi)
        {
            var entitiy = _programŞirketGrupRepository.Get(o => o.Id == Id);
            entitiy.Adı = Adı;
            entitiy.YetkiliİletişimNo = YetkiliİletişimNo;
            entitiy.ŞirketAktifmi = Convert.ToInt32(Aktifmi);
            _programŞirketGrupRepository.Update(entitiy);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult UserSearch(string UserName)
        {
            var res = _userManager.Users.Where(o => o.UserName.Contains(UserName));
            return Json(res);
        }

        public IActionResult ProgramKullanıcıPaginaiton(int offset, int limit, List<int> orderStatusId, string search)
        {
            ProgramKullanıcıPaginationModel model = new ProgramKullanıcıPaginationModel();
            model.rows = _programŞirketKullanıcıRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _programŞirketKullanıcıRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _programŞirketKullanıcıRepository.GetAllIncludedPaginationCount();
            return Json(model);
        }

        public IActionResult ProgramKullanıcıAdd(int ProgramId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var isAlreadyExists = _programŞirketKullanıcıRepository.Get(o => o.ProgramŞirketGrupId == ProgramId && o.UserId == UserId);
            if (isAlreadyExists != null)
            {
                res.status = 0;
                res.message = "Kullanıcı Daha Önceden Bir Gruba Tanımlanmış";
                return Json(res);

            }





            ProgramŞirketKullanıcı entitiy = new ProgramŞirketKullanıcı();
            entitiy.UserId = UserId;
            entitiy.ProgramŞirketGrupId = ProgramId;

            _programŞirketKullanıcıRepository.Add(entitiy);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult ProgramKullanıcıDelete(int Id)
        {
            var entity = _programŞirketKullanıcıRepository.Get(o => o.Id == Id);

            _programŞirketKullanıcıRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProgramPagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            ProgramPaginationModel model = new ProgramPaginationModel();
            model.rows = _programŞirketGrupRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _programŞirketGrupRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _programŞirketGrupRepository.GetAllIncludedPaginationCount();
            return Json(model);
        }

        public IActionResult ProgramAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProgramAdd(string Adı, string YetkiliİletişimNo)
        {
            ProgramŞirketGrup programŞirketGrup = new ProgramŞirketGrup();
            programŞirketGrup.ŞirketAktifmi = 1;
            programŞirketGrup.Adı = Adı;
            programŞirketGrup.YetkiliİletişimNo = YetkiliİletişimNo;
            _programŞirketGrupRepository.Add(programŞirketGrup);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult ProgramDelete(int Id)
        {
            var entity = _programŞirketGrupRepository.Get(o => o.Id
            == Id);
            _programŞirketGrupRepository.Delete(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
    }
}
