using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using WebIU.Models.DepoViewModels;
using WebIU.Models.DosyaViewModels;
using WebIU.Models.HelperModels;

namespace WebIU.Controllers
{
    public class DosyaYönetimiController : Controller
    {
        private readonly IDosyaRepository _dosyaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDosyaSilmeYetkiRepository _dosyaSilmeYetkiRepository;
        private readonly IDosyaİsimDeğiştirmeYetkiRepository _dosyaİsimDeğiştirmeYetkiRepository;
        private readonly IDosyaYetkiYetkiRepository _dosyaYetkiYetkiRepository;
        private readonly IDosyaİndirmeYetkiRepository _dosyaİndirmeYetkiRepository;
        private readonly IDosyaİçerikGörmeYetkiRepository _dosyaİçerikGörmeYetkiRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        public DosyaYönetimiController(IDosyaRepository dosyaRepository, IWebHostEnvironment webHostEnvironment, IDosyaSilmeYetkiRepository dosyaSilmeYetkiRepository, IDosyaİsimDeğiştirmeYetkiRepository dosyaİsimDeğiştirmeYetkiRepository, IDosyaYetkiYetkiRepository dosyaYetkiYetkiRepository, IDosyaİndirmeYetkiRepository dosyaİndirmeYetkiRepository, UserManager<AppIdentityUser> userManager, IDosyaİçerikGörmeYetkiRepository dosyaİçerikGörmeYetkiRepository)
        {
            _dosyaRepository = dosyaRepository;
            _webHostEnvironment = webHostEnvironment;
            _dosyaSilmeYetkiRepository = dosyaSilmeYetkiRepository;
            _dosyaİsimDeğiştirmeYetkiRepository = dosyaİsimDeğiştirmeYetkiRepository;
            _dosyaYetkiYetkiRepository = dosyaYetkiYetkiRepository;
            _dosyaİndirmeYetkiRepository = dosyaİndirmeYetkiRepository;
            _dosyaİçerikGörmeYetkiRepository = dosyaİçerikGörmeYetkiRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int ParentId = 0)
        {
            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            DosyaIndexViewModel model = new DosyaIndexViewModel();
            model.ParentId = ParentId;

            //model.DosyaİndirmeYetkis = _dosyaİndirmeYetkiRepository.GetAll(o => o.UserId == userId.Id);
            //model.DosyaİçerikGörmeYetkis = _dosyaİçerikGörmeYetkiRepository.GetAll(o => o.UserId == userId.Id);
            //model.DosyaİsimDeğiştirmeYetkis = _dosyaİsimDeğiştirmeYetkiRepository.GetAll(o => o.UserId == userId.Id);
            //model.DosyaYetkiYetkis = _dosyaYetkiYetkiRepository.GetAll(o => o.UserId == userId.Id);
            //model.DosyaSilmeYetkis = _dosyaSilmeYetkiRepository.GetAll(o => o.UserId == userId.Id);

            return View(model);
        }
        public IActionResult DosyaSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _dosyaRepository.Get(o => o.Id == Id);
            _dosyaRepository.Delete(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult DosyaKaydet(int ParentId = 0, string Açıklama = null, IFormFile dosya = null, string Klasörİsmi = null)
        {
            JsonResponseModel res = new JsonResponseModel();

            Dosya entity = new Dosya();
            entity.ParentId = ParentId;
            entity.Açıklama = Açıklama;

            if (dosya != null && String.IsNullOrEmpty(Klasörİsmi))
            {
                res.status = 0;
                res.message = "İçerik Hem Dosya Hemde Klasör Olamaz Lütfen Alanları Doğru girin";
                return Json(res);
            }
            if (dosya != null)
            {
                string fileExtension = Path.GetExtension(dosya.FileName);
                var rootpath = _webHostEnvironment.ContentRootPath;
                string guid = Guid.NewGuid().ToString();
                string path = rootpath + "/wwwroot/images/FileUploads/" + guid + fileExtension;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    dosya.CopyTo(fs);
                }
                entity.DosyaYolu = "/images/FileUploads/" + guid + fileExtension;
            }
            if (!String.IsNullOrEmpty(Klasörİsmi))
                entity.DosyaAdı = Klasörİsmi;
            entity.Guid = Guid.NewGuid().ToString();

            _dosyaRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult YetkiDüzenle(int DosyaId)
        {
            return View(DosyaId);
        }

        public async Task<IActionResult> UserSearch(string UserName)
        {
            var entitiy = await _userManager.Users.Where(o => o.UserName.Contains(UserName)).ToListAsync();


            return Json(entitiy);
        }




        public async Task<IActionResult> DownloadFile(int DosyaId)
        {
            var dosya = _dosyaRepository.Get(o => o.Id == DosyaId);


            var filePath = dosya.DosyaYolu;
            var fileName = dosya.DosyaAdı;


            if (System.IO.File.Exists(filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(filePath), fileName);
            }
            else
            {
                return NotFound();
            }
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            { ".txt", "text/plain" },
            { ".pdf", "application/pdf" },
            { ".doc", "application/vnd.ms-word" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xls", "application/vnd.ms-excel" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".png", "image/png" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".gif", "image/gif" },
            { ".csv", "text/csv" }
        };
        }


        public IActionResult DosyaGetPagination(int offset, int limit, List<int> orderStatusId, string search, int ParentId)
        {

            DosyaPaginationViewModel model = new DosyaPaginationViewModel();
            model.rows = _dosyaRepository.GetAllIncludedPagination(o => o.ParentId == ParentId, offset.ToString(), limit.ToString(), search);

            model.total = _dosyaRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId);
            model.totalNotFiltered = _dosyaRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId);
            return Json(model);
        }




        public IActionResult DosyaİsimDeğiştirmeYetkiEkle(int DosyaId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            DosyaİsimDeğiştirmeYetki entity = new DosyaİsimDeğiştirmeYetki();


            var enttiy = _dosyaİsimDeğiştirmeYetkiRepository.Get(o => o.UserId == UserId && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Yetki Daha Önceden Eklenmiş Lütfen Yetkili Kullanıcıları Kontrol Ediniz";
                return Json(res);

            }

            entity.UserId = UserId;
            entity.DosyaId = DosyaId;
            _dosyaİsimDeğiştirmeYetkiRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult DosyDosyaİsimDeğiştirmeYetkiSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _dosyaİsimDeğiştirmeYetkiRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Silinecek Yetki Bulunamadı";
                return Json(res);
            }

            _dosyaİsimDeğiştirmeYetkiRepository.Delete(enttiy, true);


            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
        public async Task<IActionResult> DosyaİsimDeğiştirmeYetkiKontrol(int DosyaId)
        {

            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            JsonResponseModel res = new JsonResponseModel();
            DosyaSilmeYetki entity = new DosyaSilmeYetki();

            var enttiy = _dosyaİsimDeğiştirmeYetkiRepository.Get(o => o.UserId == userId.Id && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 1;
                res.message = "Kullanıcı Yetkisi Var";
                return Json(res);
            }
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Kullanıcı Yetkisi Yok!";
                return Json(res);
            }

            res.status = 0;
            res.message = "Bilinmeyen Bir Hata Oluştur!";
            return Json(res);
        }
        public IActionResult DosyaYetkiYetkiEkle(int DosyaId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            DosyaYetkiYetki entity = new DosyaYetkiYetki();


            var enttiy = _dosyaYetkiYetkiRepository.Get(o => o.UserId == UserId && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Yetki Daha Önceden Eklenmiş Lütfen Yetkili Kullanıcıları Kontrol Ediniz";
                return Json(res);

            }


            entity.UserId = UserId;
            entity.DosyaId = DosyaId;
            _dosyaYetkiYetkiRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult DosyaYetkiYetkiSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _dosyaYetkiYetkiRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Silinecek Yetki Bulunamadı";
                return Json(res);
            }

            _dosyaYetkiYetkiRepository.Delete(enttiy, true);


            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
        public IActionResult DosyaİndirmeYetkiEkle(int DosyaId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            DosyaİndirmeYetki entity = new DosyaİndirmeYetki();


            var enttiy = _dosyaİndirmeYetkiRepository.Get(o => o.UserId == UserId && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Yetki Daha Önceden Eklenmiş Lütfen Yetkili Kullanıcıları Kontrol Ediniz";
                return Json(res);
            }

            entity.UserId = UserId;
            entity.DosyaId = DosyaId;
            _dosyaİndirmeYetkiRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult DosyaİndirmeYetkiSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _dosyaİndirmeYetkiRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Silinecek Yetki Bulunamadı";
                return Json(res);
            }

            _dosyaİndirmeYetkiRepository.Delete(enttiy, true);


            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
        public async Task<IActionResult> DosyaİndirmeYetkiKontrol(int DosyaId)
        {
            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            JsonResponseModel res = new JsonResponseModel();
            DosyaSilmeYetki entity = new DosyaSilmeYetki();


            var enttiy = _dosyaİndirmeYetkiRepository.Get(o => o.UserId == userId.Id && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 1;
                res.message = "Kullanıcı Yetkisi Var";
                return Json(res);
            }
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Kullanıcı Yetkisi Yok!";
                return Json(res);
            }

            res.status = 0;
            res.message = "Bilinmeyen Bir Hata Oluştur!";
            return Json(res);
        }
        public IActionResult DosyaSilmeYetkiEkle(int DosyaId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            DosyaSilmeYetki entity = new DosyaSilmeYetki();


            var enttiy = _dosyaSilmeYetkiRepository.Get(o => o.UserId == UserId && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Yetki Daha Önceden Eklenmiş Lütfen Yetkili Kullanıcıları Kontrol Ediniz";
                return Json(res);
            }


            entity.UserId = UserId;
            entity.DosyaId = DosyaId;
            _dosyaSilmeYetkiRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult DosyaSilmeYetkiSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _dosyaSilmeYetkiRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Silinecek Yetki Bulunamadı";
                return Json(res);
            }

            _dosyaSilmeYetkiRepository.Delete(enttiy, true);


            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }
        public IActionResult DosyaİçerikGörmeEkle(int DosyaId, string UserId)
        {
            JsonResponseModel res = new JsonResponseModel();
            DosyaİçerikGörmeYetki entity = new DosyaİçerikGörmeYetki();

            var enttiy = _dosyaİçerikGörmeYetkiRepository.Get(o => o.UserId == UserId && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Yetki Daha Önceden Eklenmiş Lütfen Yetkili Kullanıcıları Kontrol Ediniz";
                return Json(res);

            }

            entity.UserId = UserId;
            entity.DosyaId = DosyaId;
            _dosyaİçerikGörmeYetkiRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult DosyaİçerikGörmeSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _dosyaİçerikGörmeYetkiRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Silinecek Yetki Bulunamadı";
                return Json(res);
            }

            _dosyaİçerikGörmeYetkiRepository.Delete(enttiy, true);


            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }


        public async Task<IActionResult> İçerikGörmeYetkiKontrol(int DosyaId)
        {

            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);



            JsonResponseModel res = new JsonResponseModel();
            DosyaSilmeYetki entity = new DosyaSilmeYetki();

            var enttiy = _dosyaİçerikGörmeYetkiRepository.Get(o => o.UserId == userId.Id && o.DosyaId == DosyaId);
            if (enttiy != null)
            {

                var dosya = _dosyaRepository.Get(o => o.Id == DosyaId);
                if (dosya.DosyaYolu != null)
                {
                    res.status = 0;
                    res.message = "Kullanıcı Yetkisi Yok!";
                    return Json(res);
                }
                else
                {
                    res.status = 1;
                    res.message = "Kullanıcı Yetkisi Var";
                    return Json(res);
                }

            }
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Kullanıcı Yetkisi Yok!";
                return Json(res);
            }

            res.status = 0;
            res.message = "Bilinmeyen Bir Hata Oluştur!";
            return Json(res);
        }


        public async Task<IActionResult> DosyaSilmeYetkiKontrol(int DosyaId)
        {
            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            JsonResponseModel res = new JsonResponseModel();
            DosyaSilmeYetki entity = new DosyaSilmeYetki();


            var enttiy = _dosyaSilmeYetkiRepository.Get(o => o.UserId == userId.Id && o.DosyaId == DosyaId);
            if (enttiy != null)
            {
                res.status = 1;
                res.message = "Kullanıcı Yetkisi Var";
                return Json(res);
            }
            if (enttiy != null)
            {
                res.status = 0;
                res.message = "Kullanıcı Yetkisi Yok!";
                return Json(res);
            }

            res.status = 0;
            res.message = "Bilinmeyen Bir Hata Oluştur!";
            return Json(res);
        }






        public IActionResult DosyaSilmeYetkiPagination(int offset, int limit, List<int> orderStatusId, string search, int DosyaId)
        {
            DosyaSilmeYetkiPaginationViewModel model = new DosyaSilmeYetkiPaginationViewModel();
            model.rows = _dosyaSilmeYetkiRepository.GetAllIncludedPagination(o => o.DosyaId == DosyaId, offset.ToString(), limit.ToString(), search);
            model.total = _dosyaSilmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            model.totalNotFiltered = _dosyaSilmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            return Json(model);
        }


        public IActionResult DosyaİsimDeğiştirmeYetkiPagination(int offset, int limit, List<int> orderStatusId, string search, int DosyaId)
        {
            DosyaİsimDeğiştirmeYetkiPaginationViewModel model = new DosyaİsimDeğiştirmeYetkiPaginationViewModel();
            model.rows = _dosyaİsimDeğiştirmeYetkiRepository.GetAllIncludedPagination(o => o.DosyaId == DosyaId, offset.ToString(), limit.ToString(), search);
            model.total = _dosyaİsimDeğiştirmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            model.totalNotFiltered = _dosyaİsimDeğiştirmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            return Json(model);
        }

        public IActionResult DosyaYetkiYetkiPagination(int offset, int limit, List<int> orderStatusId, string search, int DosyaId)
        {
            DosyaYetkiYetkiPaginationViewModel model = new DosyaYetkiYetkiPaginationViewModel();
            model.rows = _dosyaYetkiYetkiRepository.GetAllIncludedPagination(o => o.DosyaId == DosyaId, offset.ToString(), limit.ToString(), search);
            model.total = _dosyaYetkiYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            model.totalNotFiltered = _dosyaYetkiYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            return Json(model);
        }
        public IActionResult DosyaİndirmeYetkiPagination(int offset, int limit, List<int> orderStatusId, string search, int DosyaId)
        {
            DosyaİndirmeYetkiPaginationViewModel model = new DosyaİndirmeYetkiPaginationViewModel();
            model.rows = _dosyaİndirmeYetkiRepository.GetAllIncludedPagination(o => o.DosyaId == DosyaId, offset.ToString(), limit.ToString(), search);
            model.total = _dosyaİndirmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            model.totalNotFiltered = _dosyaİndirmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            return Json(model);
        }

        public IActionResult DosyaİçerikGörmeYetkiPagination(int offset, int limit, List<int> orderStatusId, string search, int DosyaId)
        {
            DosyaİçerikGörmeYetkiPaginationViewModel model = new DosyaİçerikGörmeYetkiPaginationViewModel();
            model.rows = _dosyaİçerikGörmeYetkiRepository.GetAllIncludedPagination(o => o.DosyaId == DosyaId, offset.ToString(), limit.ToString(), search);
            model.total = _dosyaİçerikGörmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            model.totalNotFiltered = _dosyaİçerikGörmeYetkiRepository.GetAllIncludedPaginationCount(o => o.DosyaId == DosyaId);
            return Json(model);
        }




    }
}
