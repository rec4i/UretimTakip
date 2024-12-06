using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Vml.Office;
using Entities.Abstract;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.Token;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
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
        private readonly SignInManager<AppIdentityUser> _signInManager;

        public DosyaYönetimiController(IDosyaRepository dosyaRepository, IWebHostEnvironment webHostEnvironment, IDosyaSilmeYetkiRepository dosyaSilmeYetkiRepository, IDosyaİsimDeğiştirmeYetkiRepository dosyaİsimDeğiştirmeYetkiRepository, IDosyaYetkiYetkiRepository dosyaYetkiYetkiRepository, IDosyaİndirmeYetkiRepository dosyaİndirmeYetkiRepository, UserManager<AppIdentityUser> userManager, IDosyaİçerikGörmeYetkiRepository dosyaİçerikGörmeYetkiRepository, SignInManager<AppIdentityUser> signInManager)
        {
            _dosyaRepository = dosyaRepository;
            _webHostEnvironment = webHostEnvironment;
            _dosyaSilmeYetkiRepository = dosyaSilmeYetkiRepository;
            _dosyaİsimDeğiştirmeYetkiRepository = dosyaİsimDeğiştirmeYetkiRepository;
            _dosyaYetkiYetkiRepository = dosyaYetkiYetkiRepository;
            _dosyaİndirmeYetkiRepository = dosyaİndirmeYetkiRepository;
            _dosyaİçerikGörmeYetkiRepository = dosyaİçerikGörmeYetkiRepository;
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public string GetClientIpAddress(HttpContext httpContext)
        {
            string ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();

            // Eğer X-Forwarded-For başlığı varsa, onu kontrol et
            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ipAddress = httpContext.Request.Headers["X-Forwarded-For"].ToString();

                // X-Forwarded-For birden fazla IP adresi içerebilir, ilkini al
                if (ipAddress.Contains(","))
                {
                    ipAddress = ipAddress.Split(',')[0];
                }
            }

            return ipAddress;
        }

        public async Task<IActionResult> DosyaYazmaYoluOluştur(int DosyaId)
        {

            var rootpath = _webHostEnvironment.ContentRootPath;
            var dosya = _dosyaRepository.Get(o => o.Id == DosyaId);
            string path = rootpath + "wwwroot/DosyaYönetimi/" + CreateFileDestinaton(dosya.Id);
            var copyPath = rootpath + "wwwroot/YazilacakDosyalar/" + dosya.Guid;
            string clientIp = GetClientIpAddress(HttpContext);


            if (!Directory.Exists(copyPath))
            {
                CopyDirectory(path, copyPath);
            }

            string command = "DosyaKontrolAppv2.exe";
            string arguments = $"{rootpath}wwwroot\\YazilacakDosyalar 192.168.1.34 {dosya.Guid} {clientIp}";

            // ProcessStartInfo sınıfı ile işlem bilgilerini ayarla
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = $"/c {command} {arguments}";
            processStartInfo.RedirectStandardOutput = true; // Çıktıyı yakalamak için
            processStartInfo.UseShellExecute = false; // Yeni bir pencere açmadan çalıştırmak için
            processStartInfo.CreateNoWindow = false; // Pencere açmamak için

            // Process sınıfı ile işlemi başlat
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
            }

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            res.data = "\\\\192.168.1.34\\YazilacakDosyalar\\" + dosya.Guid;

            return Json(res);
        }


        public async Task<IActionResult> DosyaYoluOluştur(int DosyaId)
        {
            JsonResponseModel res = new JsonResponseModel();

            string clientIp = GetClientIpAddress(HttpContext);

            var rootpath = _webHostEnvironment.ContentRootPath;
            var dosya = _dosyaRepository.Get(o => o.Id == DosyaId);
            string path = rootpath + "wwwroot/DosyaYönetimi/" + CreateFileDestinaton(dosya.Id);
            var copyPath = rootpath + "wwwroot/IslenecekDosyalar/" + dosya.Guid;



            var _processes = Process.GetProcesses()
                              .ToList().Where(o => o.ProcessName.Contains("DosyaKontrolApp" + dosya.Guid));
            // Diğer işlemleri sonlandır
            foreach (var process in _processes)
            {
                process.Kill();
                process.WaitForExit(); // İsteğe bağlı: işlem tamamen kapanana kadar bekler
            }


            if (Directory.Exists(copyPath))
            {

                try
                {
                    if (Directory.Exists(copyPath))
                    {
                        // Klasörü ve içeriğini sil
                        Directory.Delete(copyPath, true);
                        Console.WriteLine("Klasör ve içeriği başarıyla silindi.");
                        CopyDirectory(path, copyPath);

                    }
                    else
                    {
                        Console.WriteLine("Klasör bulunamadı.");
                        res.status = 0;
                        res.message = "Klasör bulunamadı ";
                        return Json(res);
                    }
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Hata " + ex.Message;
                    return Json(res);
                }



            }
            else
            {
                CopyDirectory(path, copyPath);

            }



            //string[] files = Directory.GetFiles(rootpath);

            //var dosyaAdı = files.Where(o => o.Contains("DosyaKontrolApp.exe"));

            //// Mevcut dosya yolu
            //string oldFilePath = dosyaAdı.FirstOrDefault();

            //// Yeni dosya yolu (dosyanın yeni adı)
            //string newFilePath = $"DosyaKontrolApp{dosya.Guid}.exe";


            //try
            //{
            //    // Dosyanın adını değiştirmek için dosyayı taşı
            //    System.IO.File.Copy(oldFilePath, newFilePath);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            //}


            //string command = $"DosyaKontrolApp{dosya.Guid}.exe";
            //string arguments = rootpath + $"wwwroot\\IslenecekDosyalar 192.168.1.34 {dosya.Guid} {clientIp} {dosya.DosyaAdı} 1";

            //// ProcessStartInfo sınıfı ile işlem bilgilerini ayarla
            //ProcessStartInfo processStartInfo = new ProcessStartInfo();
            //processStartInfo.FileName = "cmd.exe";
            //processStartInfo.Arguments = $"/c {command} {arguments}";
            //processStartInfo.RedirectStandardOutput = true; // Çıktıyı yakalamak için
            //processStartInfo.UseShellExecute = false; // Yeni bir pencere açmadan çalıştırmak için
            //processStartInfo.CreateNoWindow = false; // Pencere açmamak için

            //// Process sınıfı ile işlemi başlat
            //using (Process process = new Process())
            //{
            //    process.StartInfo = processStartInfo;
            //    process.Start();
            //}









            res.status = 1;
            res.message = "İşlem Başarılı";
            res.data = "\\\\192.168.1.34\\IslenecekDosyalar\\" + dosya.Guid;

            return Json(res);
        }

        public async Task<IActionResult> DeğişmişDosyayıKaydet(string Guid, string UserId, string IslemTuru, string Gerekce, string İşlemTürü)
        {
            JsonResponseModel res = new JsonResponseModel();
            var rootpath = _webHostEnvironment.ContentRootPath;
            var dosya = _dosyaRepository.Get(o => o.Guid == Guid);

            var varolanDosya = _dosyaRepository.Get(o => o.Id == dosya.Id);
            var varolandDosyaParents = _dosyaRepository.GetAll(o => o.DosyaAdı.Contains(varolanDosya.DosyaAdı));


            var destinationDir = rootpath + "wwwroot/DosyaYönetimi/" + CreateFileDestinaton(varolanDosya.ParentId) + varolanDosya.DosyaAdı + " İşlem No " + varolandDosyaParents.Count();

            if (İşlemTürü == "1")
            {
                CopyDirectoryAndCreateDatabeseObject(rootpath + "wwwroot/IslenecekDosyalar/" + Guid, destinationDir, dosya.ParentId, UserId, IslemTuru, Gerekce);
            }
            else
            {
                CopyDirectoryAndCreateDatabeseObject(rootpath + "wwwroot/YazilacakDosyalar/" + Guid, destinationDir, dosya.ParentId, UserId, IslemTuru, Gerekce);
            }


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> YeniYazılanDosyayıKaydet(string Guid, string UserId, string IslemTuru, string Gerekce, string remoteIp)
        {
            string clientIp = GetClientIpAddress(HttpContext);

            JsonResponseModel res = new JsonResponseModel();
            var rootpath = _webHostEnvironment.ContentRootPath;
            var dosya = _dosyaRepository.Get(o => o.Guid == Guid);
            var varolanDosya = _dosyaRepository.Get(o => o.Id == dosya.Id);
            var varolandDosyaParents = _dosyaRepository.GetAll(o => o.DosyaAdı.Contains(varolanDosya.DosyaAdı));
            var destinationDir = rootpath + "wwwroot/DosyaYönetimi/" + CreateFileDestinaton(varolanDosya.ParentId) + varolanDosya.DosyaAdı;
            CopyDirectoryAndCreateDatabeseObject(rootpath + "wwwroot/YazilacakDosyalar/" + Guid, destinationDir, dosya.Id, UserId, IslemTuru, Gerekce);
            string folderPath = rootpath + "wwwroot/YazilacakDosyalar/" + Guid;
            //try
            //{
            //    if (Directory.Exists(folderPath))
            //    {


            //        string[] files = Directory.GetFiles(rootpath);

            //        var dosyaAdı = files.Where(o => o.Contains("DosyaKontrolApp.exe"));

            //        // Mevcut dosya yolu
            //        string oldFilePath = dosyaAdı.FirstOrDefault();

            //        // Yeni dosya yolu (dosyanın yeni adı)
            //        string newFilePath = $"DosyaKontrolApp{dosya.Guid}.exe";


            //        try
            //        {
            //            // Dosyanın adını değiştirmek için dosyayı taşı
            //            System.IO.File.Copy(oldFilePath, newFilePath);
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            //        }



            //        var _processes = Process.GetProcesses()
            //                   .ToList().Where(o => o.ProcessName.Contains("DosyaKontrolApp" + dosya.Guid));
            //        // Diğer işlemleri sonlandır
            //        foreach (var process in _processes)
            //        {
            //            process.Kill();
            //            process.WaitForExit(); // İsteğe bağlı: işlem tamamen kapanana kadar bekler
            //        }


            //        string command = $"DosyaKontrolApp{dosya.Guid}.exe";
            //        string arguments = rootpath + $"wwwroot\\YazilacakDosyalar 192.168.1.34 {dosya.Guid} {remoteIp} {dosya.DosyaAdı} 0";

            //        // ProcessStartInfo sınıfı ile işlem bilgilerini ayarla
            //        ProcessStartInfo processStartInfo = new ProcessStartInfo();
            //        processStartInfo.FileName = "cmd.exe";
            //        processStartInfo.Arguments = $"/c {command} {arguments}";
            //        processStartInfo.RedirectStandardOutput = true; // Çıktıyı yakalamak için
            //        processStartInfo.UseShellExecute = false; // Yeni bir pencere açmadan çalıştırmak için
            //        processStartInfo.CreateNoWindow = false; // Pencere açmamak için

            //        // Process sınıfı ile işlemi başlat
            //        using (Process process = new Process())
            //        {
            //            process.StartInfo = processStartInfo;
            //            process.Start();
            //        }





            //    }
            //    else
            //    {
            //        Console.WriteLine("Klasör bulunamadı.");
            //        res.status = 0;
            //        res.message = "Klasör bulunamadı ";
            //        return Json(res);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    res.status = 0;
            //    res.message = "Hata " + ex.Message;
            //    return Json(res);
            //}
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public void CopyDirectoryAndCreateDatabeseObject(string sourceDir, string destinationDir, int? parentId, string UserId, string IslemTuru, string Gerekce)
        {
            // Hedef klasör yoksa oluştur
            var folderGuid = Guid.NewGuid().ToString();
            string userName = "";
            if (UserId != null)
            {
                userName = _userManager.Users.Where(o => o.Id == UserId.Replace("\"", "")).FirstOrDefault().UserName;
            }
            Dosya folderEntity = null;
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
                // Klasör için veritabanına kayıt ekle
                folderEntity = new Dosya
                {
                    ParentId = parentId,
                    DosyaAdı = Path.GetFileName(destinationDir),
                    Guid = folderGuid,
                    Açıklama = userName + "////" + IslemTuru + "/////" + Gerekce
                };
                folderEntity = _dosyaRepository.Add(folderEntity);
            }



            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFileName = Path.Combine(destinationDir, Path.GetFileName(file));
                System.IO.File.Copy(file, destFileName, true);

                // Dosya için veritabanına kayıt ekle
                var fileGuid = Guid.NewGuid().ToString();
                var fileEntity = new Dosya
                {
                    ParentId = folderEntity == null ? parentId : folderEntity.Id,  // Veritabanında otomatik olarak atanacak ID
                    DosyaAdı = Path.GetFileName(file),
                    DosyaYolu = destFileName,
                    Guid = fileGuid,
                    Açıklama = "Dosya"
                };
                fileEntity = _dosyaRepository.Add(fileEntity);
            }

            // Kaynak klasördeki alt klasörleri al ve yeniden aynı metod ile kopyala
            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string destDirName = Path.Combine(destinationDir, Path.GetFileName(directory));
                CopyDirectoryAndCreateDatabeseObject(directory, destDirName, folderEntity == null ? parentId : folderEntity.Id, UserId, IslemTuru, Gerekce);
            }

        }



        public void CopyDirectory(string sourceDir, string destinationDir)
        {
            // Hedef klasör yoksa oluştur
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Kaynak klasördeki dosyaları al ve hedef klasöre kopyala
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFileName = Path.Combine(destinationDir, Path.GetFileName(file));
                System.IO.File.Copy(file, destFileName, true);
            }

            // Kaynak klasördeki alt klasörleri al ve yeniden aynı metod ile kopyala
            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                string destDirName = Path.Combine(destinationDir, Path.GetFileName(directory));
                CopyDirectory(directory, destDirName);
            }

        }

        public string CreateFileDestinaton(int? ParentId, string rootFileName = null)
        {
            var dosyaYolu = "";
            int? cuurParent = ParentId;
            List<string> dosyalar = new List<string>();


            while (true)
            {

                var dosyaParent = _dosyaRepository.Get(o => o.Id == cuurParent);
                if (dosyaParent == null)
                {
                    break;
                }
                if (dosyaParent.ParentId == 0)
                {
                    if (rootFileName != null)
                    {
                        //     dosyaYolu += rootFileName;
                        dosyalar.Add(rootFileName);
                        cuurParent = dosyaParent.ParentId;
                        break;
                    }
                    dosyalar.Add(dosyaParent.DosyaAdı);
                    //   dosyaYolu += dosyaParent.DosyaAdı;
                    cuurParent = dosyaParent.ParentId;

                    break;
                }
                dosyalar.Add(dosyaParent.DosyaAdı);
                // dosyaYolu += dosyaParent.DosyaAdı + "/";
                cuurParent = dosyaParent.ParentId;

            }
            for (int i = dosyalar.Count() - 1; i >= 0; i--)
            {
                if (dosyalar[i].Contains("."))
                {
                    dosyaYolu += dosyalar[i];


                }
                dosyaYolu += dosyalar[i] + "/";

            }

            return dosyaYolu;
        }


        public async Task<IActionResult> Index(int ParentId = 0)
        {
            var userId = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            DosyaIndexViewModel model = new DosyaIndexViewModel();
            model.ParentId = ParentId;


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
            var rootpath = _webHostEnvironment.ContentRootPath;


            if (dosya != null && !String.IsNullOrEmpty(Klasörİsmi))
            {
                res.status = 0;
                res.message = "İçerik Hem Dosya Hemde Klasör Olamaz Lütfen Alanları Doğru girin";
                return Json(res);
            }
            if (dosya != null)
            {

                var dosyaYolu = CreateFileDestinaton(ParentId);




                string fileExtension = Path.GetExtension(dosya.FileName);
                string guid = Guid.NewGuid().ToString();
                string path = rootpath + "/wwwroot/DosyaYönetimi/" + dosyaYolu + dosya.FileName;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    dosya.CopyTo(fs);
                }
                entity.DosyaYolu = "/DosyaYönetimi/" + dosyaYolu + "/" + dosya.FileName + fileExtension;
                entity.DosyaAdı = dosya.FileName;
            }
            if (!String.IsNullOrEmpty(Klasörİsmi))
            {
                var dosyaYolu = CreateFileDestinaton(ParentId);

                entity.DosyaAdı = Klasörİsmi;
                string path = rootpath + "/wwwroot/DosyaYönetimi/" + dosyaYolu + Klasörİsmi;

                Directory.CreateDirectory(path);


            }
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

            var rootpath = _webHostEnvironment.ContentRootPath;

            if (System.IO.File.Exists(rootpath + filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(rootpath + filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(rootpath + filePath), fileName);
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
