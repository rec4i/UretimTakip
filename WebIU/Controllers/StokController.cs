using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.OtherEntities;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;
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
        private readonly IStokKoduTanımRepository _stokKoduTanımRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;

        public StokController(IStokRepository stokRepository, IBirimRepository birimRepository, IDepoRepository depoRepository, IStokHarektiRepository stokHarektiRepository, IStokKoduTanımRepository stokKoduTanımRepository, IProgramŞirketGrupRepository programŞirketGrupRepository)
        {
            _stokRepository = stokRepository;
            _birimRepository = birimRepository;
            _depoRepository = depoRepository;
            _stokHarektiRepository = stokHarektiRepository;
            _stokKoduTanımRepository = stokKoduTanımRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
        }

        public async Task<IActionResult> Index(int ÜstStokId, string StokKoduHazır)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            StokIndexViewModel model = new StokIndexViewModel();
            model.Birims = _birimRepository.GetAll();
            model.ÜstStokId = ÜstStokId;
            model.StokKoduHazır = StokKoduHazır;
            model.Depos = _depoRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup);
            var entntiy = _stokKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup);
            model.StokKoduTanım = entntiy.Tanım;
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


        private (string, bool) KodDüzenle(string cariKodu)
        {
            string SearchText = "";

            if (!string.IsNullOrEmpty(cariKodu))
            {
                bool[] blokDataVarmı = new bool[cariKodu.Replace(' ', '_').Split(".").Length];
                for (int i = 0; i < cariKodu.Replace(' ', '_').Split(".").Length; i++)
                {
                    foreach (var _item in cariKodu.Replace(' ', '_').Split(".")[i])
                    {
                        if (_item == '_')
                        {
                            blokDataVarmı[i] = false;

                        }
                        if (Regex.IsMatch(_item.ToString(), @"[A-Za-z0-9]"))
                        {

                            blokDataVarmı[i] = true;
                        }
                    }

                }
                if (blokDataVarmı.Any(o => o == true))
                {
                    for (int i = 0; i < blokDataVarmı.Length; i++)
                    {
                        bool devammı = false;
                        SearchText += cariKodu.Replace(' ', '_').Split(".")[i] + ".";
                        for (int j = i + 1; j < blokDataVarmı.Length; j++)
                        {
                            if (blokDataVarmı[j])
                            {
                                devammı = true;
                            }
                        }
                        if (!devammı)
                        {
                            SearchText = SearchText.Remove(SearchText.Length - 1) + "";
                            break;
                        }
                    }
                }

                SearchText = SearchText.Replace(",", ".");
            }

            return (SearchText, true);

        }

        public async Task<IActionResult> StokKaydet(string StokKodu, string StokAdı, int BirimId, string Açıklama, decimal StokAdeti, int DepoId, bool Baslıkmı, int ÜstStokId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            JsonResponseModel res = new JsonResponseModel();
            Stok addedEntity = new Stok();
            try
            {
                Stok entity = new Stok();
                entity.StokAdı = StokAdı;
                entity.BirimId = Baslıkmı == false ? null : BirimId;
                entity.Açıklama = Açıklama;
                entity.ÜstStokId = ÜstStokId;
                entity.StokKodu = KodDüzenle(StokKodu).Item1;
                entity.ProgramŞirketGrupId = userGroup;

                if (KodDüzenle(StokKodu).Item2 == false)
                {
                    res.status = 0;
                    res.message = "Stok Kodu Yanlış Girildi Lütfen Düzelterek Tekrar Giriş Yapınız!";
                    return Json(res);
                }
                addedEntity = _stokRepository.Add(entity);
            }
            catch (Exception)
            {
                res.status = 0;
                res.message = "İşlem Sırasında Hata Oluştu Lütfen Yöneticiye Danışın";
                return Json(res);

            }

            if (Baslıkmı == true)
            {
                StokHareket stokHarekti = new StokHareket();
                stokHarekti.StokId = addedEntity.Id;
                stokHarekti.Adet = StokAdeti;
                stokHarekti.HareketTipi = 1;
                stokHarekti.DepoId = DepoId;
                _stokHarektiRepository.Add(stokHarekti);
            }


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

        public IActionResult StokPagination(int offset, int limit, List<int> orderStatusId, string search, int ÜstStokId)
        {
            StokPaginatonModel model = new StokPaginatonModel();
            model.rows = _stokRepository.GetAllIncludedPagination(o => o.ÜstStokId == ÜstStokId, offset.ToString(), limit.ToString(), search);
            model.total = _stokRepository.GetAllIncludedPaginationCount(o => o.ÜstStokId == ÜstStokId);
            model.totalNotFiltered = _stokRepository.GetAllIncludedPaginationCount(o => o.ÜstStokId == ÜstStokId);


            return Json(model);
        }

    }
}
