using DataAccess.Abstract;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIU.Models.UrunViewModels;

namespace WebIU.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunAşamalarıRepository _urunAşamalarıRepository;
        private readonly IUrunRepository _urunRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly ITezgahRepository _tezgahRepository;

        public UrunController(IUrunAşamalarıRepository urunAşamalarıRepository, IUrunRepository urunRepository, UserManager<AppIdentityUser> userManager, ITezgahRepository tezgahRepository)
        {
            _urunAşamalarıRepository = urunAşamalarıRepository;
            _urunRepository = urunRepository;
            _userManager = userManager;
            _tezgahRepository = tezgahRepository;
        }
        public IActionResult Index(string qr)
        {
            var urun = _urunRepository.GetAllIncluded(o => o.Guid == qr).FirstOrDefault();
            UrunIndexViewModel model = new UrunIndexViewModel();
            model.UrunAşamalarıs = _urunAşamalarıRepository.GetAllIncluded(o => o.UrunId == urun.Id);
            model.Urun = urun;
            model.Tezgahs = _tezgahRepository.GetAllIncluded();
            foreach (var item in model.UrunAşamalarıs)
            {
                if (item.İşeBaşlamaZamanı == null)
                {
                    item.İşeBaşlamaZamanı = DateTime.Now;
                }
                _urunAşamalarıRepository.Update(item);
            }




            //entity.İşeBaşlamaZamanı 
            return View(model);
        }


        public IActionResult SetUrunAşama(int Id, bool TamamlanmaDurumu)
        {
            var UserProflieId = _userManager.GetUserAsync(HttpContext.User).Result.Id;
            var entity = _urunAşamalarıRepository.Get(o => o.Id
            == Id);
            entity.TamamlanmaDurumu = TamamlanmaDurumu;
            entity.İşiÜstlenenKullanıcıId = UserProflieId;
            entity.İşiBitirmeZamanı = DateTime.Now;

            _urunAşamalarıRepository.Update(entity);
            return Json("İşlem Başarılı");


        }

        public IActionResult UrunListesi(int Id)
        {
            UrulListViewModel model = new UrulListViewModel();

            model.Uruns = _urunRepository.GetAllIncluded(o => o.İşEmriId == Id);



            return View(model);
        }


    }
}
