using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using Entities.Concrete.Identity;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.DotNet.MSIdentity.Shared;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.Cms;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using WebIU.Models.CariViewModels;
using WebIU.Models.DepoViewModels;
using WebIU.Models.HelperModels;
using WebIU.Models.ProgramViewModels;

namespace WebIU.Controllers
{
    public class CariController : Controller
    {

        private readonly ICariRepository _cariRepository;
        private readonly IProgramŞirketGrupRepository _programŞirketGrupRepository;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly ICariKoduTanımRepository _cariKoduTanımRepository;
        private readonly IStokRepository _stokRepository;
        private readonly IStokKoduTanımRepository _stokKoduTanımRepository;
        private readonly IFiyatRepository _fiyatRepository;
        private readonly IFaturaBaslıkRepository _faturaBaslıkRepository;
        private readonly IFaturaDetayRepository _faturaDetayRepository;
        private readonly IFaturaSeriRepository _faturaSeriRepository;
        private readonly IÖdemeSeriRepository _ödemeSeriRepository;
        private readonly IÖdemeRepository _ödemeRepository;
        private readonly IKasaKoduTanımRepository _kasaKoduTanımRepository;
        private readonly IKasaRepository _kasaRepository;
        private readonly IDepoKoduTanımRepository _depoKoduTanımRepository;
        private readonly IDepoRepository _depoRepository;
        private readonly IStokHarektiRepository _stokHarektiRepository;
        public CariController(ICariRepository cariRepository, IProgramŞirketGrupRepository programŞirketGrupRepository, UserManager<AppIdentityUser> userManager, ICariKoduTanımRepository cariKoduTanımRepository, IStokRepository stokRepository, IStokKoduTanımRepository stokKoduTanımRepository, IFiyatRepository fiyatRepository, IFaturaBaslıkRepository faturaBaslıkRepository, IFaturaDetayRepository faturaDetayRepository, IFaturaSeriRepository faturaSeriRepository, IÖdemeSeriRepository ödemeSeriRepository, IÖdemeRepository ödemeRepository, IKasaKoduTanımRepository kasaKoduTanımRepository, IKasaRepository kasaRepository, IDepoKoduTanımRepository depoKoduTanımRepository, IDepoRepository depoRepository, IStokHarektiRepository stokHarektiRepository)
        {
            _cariRepository = cariRepository;
            _programŞirketGrupRepository = programŞirketGrupRepository;
            _userManager = userManager;
            _cariKoduTanımRepository = cariKoduTanımRepository;
            _stokRepository = stokRepository;
            _stokKoduTanımRepository = stokKoduTanımRepository;
            _fiyatRepository = fiyatRepository;
            _faturaBaslıkRepository = faturaBaslıkRepository;
            _faturaDetayRepository = faturaDetayRepository;
            _faturaSeriRepository = faturaSeriRepository;
            _ödemeSeriRepository = ödemeSeriRepository;
            _ödemeRepository = ödemeRepository;
            _kasaKoduTanımRepository = kasaKoduTanımRepository;
            _kasaRepository = kasaRepository;
            _depoKoduTanımRepository = depoKoduTanımRepository;
            _depoRepository = depoRepository;
            _stokHarektiRepository = stokHarektiRepository;

        }

        public async Task<IActionResult> FaturaPrint(int Id)
        {
            FaturaPrintViewModel model = new FaturaPrintViewModel();
            model.FaturaBaslık = _faturaBaslıkRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            model.FaturaDetay = _faturaDetayRepository.GetAllIncluded(o => o.FaturaBaslıkId == Id);
            model.Cari = _cariRepository.Get(o => o.Id == model.FaturaBaslık.CariId);


            return View(model);
        }
        public async Task<IActionResult> ToplamBorçGetir(int cariId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var faturaBaşlıks = _faturaBaslıkRepository.GetAll(o => o.CariId == cariId && o.FaturaTürü == 2);
            JsonResponseModel res = new JsonResponseModel();
            List<FaturaDetay> faturaDetays = new List<FaturaDetay>();
            foreach (var item in faturaBaşlıks)
            {
                faturaDetays.AddRange(_faturaDetayRepository.GetAll(o => o.FaturaBaslıkId == item.Id));
            }
            decimal toplamTutar = 0;
            foreach (var item in faturaDetays)
            {
                toplamTutar += item.Adet * ((item.Fiyat) + item.Fiyat / 100 * item.KdvOranı);
            }
            List<Ödeme> ödemeler = new List<Ödeme>();
            foreach (var item in faturaBaşlıks)
            {
                ödemeler.AddRange(_ödemeRepository.GetAll(o => o.FaturaBaslıkId == item.Id && o.ProgramŞirketGrupId == userGroup));
            }
            var toplamÖdemeler = ödemeler.Sum(o => o.Tutar);
            res.data = toplamTutar - toplamÖdemeler;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public async Task<IActionResult> ÖdemePaginaiton(int offset, int limit, string search, int FaturaId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            ÖdemePaginaitonViewModel model = new ÖdemePaginaitonViewModel();
            model.rows = _ödemeRepository.GetAllIncludedPagination(o => o.FaturaBaslıkId == FaturaId && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _ödemeRepository.GetAllIncludedPaginationCount(o => o.FaturaBaslıkId == FaturaId && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _ödemeRepository.GetAllIncludedPaginationCount(o => o.FaturaBaslıkId == FaturaId && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }

        public async Task<IActionResult> ÖdemeKaydet(decimal Tutar, int KasaId, int ÖdemeSeriNoId, int ÖdemeSeriNo, int FaturaId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();

            var ödemeSeriTürü = _ödemeSeriRepository.GetAll(o => o.Id == ÖdemeSeriNoId).FirstOrDefault().SeriTürü;
            if (await FaturaKalanBorçGetirDecimal(FaturaId) < Tutar)
            {
                res.status = 0;
                res.message = "En Fazla Borç Tutarı Kadar Ödeme Alınabilir";
                return Json(res);

            }
            if (_ödemeRepository.GetAll(o => o.ÖdemeTürü == ödemeSeriTürü && o.SeriNo == ÖdemeSeriNo && o.ÖdemeSeriId == ÖdemeSeriNoId).Count() >= 1)
            {
                res.status = 0;
                res.message = "Seri No Daha Önceden Kullanılmış lütfen Yeni Seri No Üretin";
                return Json(res);
            }
            Ödeme entity = new Ödeme();
            entity.ProgramŞirketGrupId = userGroup;
            entity.Tutar = Tutar;
            entity.ÖdemeSeriId = ÖdemeSeriNoId;
            entity.SeriNo = ÖdemeSeriNo;
            entity.FaturaBaslıkId = FaturaId;
            entity.ÖdemeTürü = ödemeSeriTürü;

            _ödemeRepository.Add(entity);


            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<decimal> FaturaKalanBorçGetirDecimal(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            var faturaDetay = _faturaDetayRepository.GetAll(o => o.FaturaBaslıkId == Id);
            decimal toplamTutar = 0;
            foreach (var item in faturaDetay)
            {
                toplamTutar += item.Adet * ((item.Fiyat) + item.Fiyat / 100 * item.KdvOranı);
            }
            var toplamÖdemeler = _ödemeRepository.GetAll(o => o.FaturaBaslıkId == Id && o.ProgramŞirketGrupId == userGroup).Sum(o => o.Tutar);
            res.data = toplamTutar - toplamÖdemeler;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return toplamTutar - toplamÖdemeler;
        }
        public async Task<IActionResult> FaturaKalanBorçGetir(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            var faturaDetay = _faturaDetayRepository.GetAll(o => o.FaturaBaslıkId == Id);
            decimal toplamTutar = 0;
            foreach (var item in faturaDetay)
            {
                toplamTutar += item.Adet * ((item.Fiyat) + item.Fiyat / 100 * item.KdvOranı);
            }
            var toplamÖdemeler = _ödemeRepository.GetAll(o => o.FaturaBaslıkId == Id && o.ProgramŞirketGrupId == userGroup).Sum(o => o.Tutar);
            res.data = toplamTutar - toplamÖdemeler;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public async Task<IActionResult> FaturaSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _faturaBaslıkRepository.Get(o => o.Id == Id);
            _faturaBaslıkRepository.Delete(entity);

            var StokHareketleri = _stokHarektiRepository.GetAll(o => o.FaturaBaslıkId == Id);
            foreach (var item in StokHareketleri)
            {
                _stokHarektiRepository.Delete(item);
            }
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public async Task<IActionResult> FaturaPaginaiton(int offset, int limit, List<int> orderStatusId, string search, int CariId, DateTime BasTar, DateTime BitTar)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            FaturaPaginaitonViewModel model = new FaturaPaginaitonViewModel();
            model.rows = _faturaBaslıkRepository.GetAllIncludedPagination(o => o.CariId == CariId && o.AddedDate >= BasTar && o.AddedDate <= BitTar, offset.ToString(), limit.ToString(), search);
            model.total = _faturaBaslıkRepository.GetAllIncludedPaginationCount(o => o.CariId == CariId && o.AddedDate >= BasTar && o.AddedDate <= BitTar);
            model.totalNotFiltered = _faturaBaslıkRepository.GetAllIncludedPaginationCount(o => o.CariId == CariId && o.AddedDate >= BasTar && o.AddedDate <= BitTar);

            return Json(model);
        }


        public async Task<IActionResult> FaturaOlustur(string[] StokIds, string[] Fiyats, string[] Kdv, string[] Miktars, int CariId, int FaturaTuru, string FaturaNo, int SeriNoId, int SeriNo, int DepoId)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            if (String.IsNullOrEmpty(FaturaNo))
            {
                res.status = 0;
                res.message = "Lütfen Fatura No Bilgilisini Giriniz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(SeriNo.ToString()))
            {
                res.status = 0;
                res.message = "Lütfen Seri No Bilgilisini Giriniz";
                return Json(res);
            }
            if (StokIds.Length <= 0)
            {
                res.status = 0;
                res.message = "Lütfen  Satır Giriniz";
                return Json(res);
            }
            FaturaBaslık faturaBaslık = new FaturaBaslık();
            faturaBaslık.FaturaTürü = FaturaTuru;
            faturaBaslık.CariId = CariId;
            faturaBaslık.ProgramŞirketGrupId = userGroup;
            faturaBaslık.FaturaNo = FaturaNo;
            faturaBaslık.FaturaSeriId = SeriNoId;
            faturaBaslık.SeriNo = SeriNo;
            faturaBaslık.AddedDate = DateTime.Now;
            try
            {
                faturaBaslık = _faturaBaslıkRepository.Add(faturaBaslık);
            }
            catch (Exception ex)
            {
                res.status = 0;
                res.message = "Fatura Başlığı Oluşturulurken Hata Oluştu . Hata: " + ex.Message;
                return Json(res);

            }

            for (int i = 0; i < StokIds.Length; i++)
            {
                try
                {
                    FaturaDetay faturaDetay = new FaturaDetay();
                    faturaDetay.Fiyat = Convert.ToDecimal(Fiyats[i]);
                    faturaDetay.Adet = Convert.ToDecimal(Miktars[i]);
                    faturaDetay.StokId = Convert.ToInt32(StokIds[i]);
                    faturaDetay.KdvOranı = Convert.ToDecimal(Kdv[i]);
                    faturaDetay.FaturaBaslıkId = faturaBaslık.Id;
                    _faturaDetayRepository.Add(faturaDetay);
                }
                catch (Exception ex)
                {
                    res.status = 0;
                    res.message = "Fatura Satırı Oluşturulurken Hata Oluştu. Hata : " + ex.Message;
                    return Json(res);
                }
                try
                {
                    StokHareket stokHareket = new StokHareket();
                    stokHareket.ProgramŞirketGrupId = userGroup;
                    stokHareket.Adet = Convert.ToDecimal(Miktars[i]);
                    if (FaturaTuru == 1)
                        stokHareket.HareketTipi = 3;
                    if (FaturaTuru == 2)
                        stokHareket.HareketTipi = 4;
                    if (FaturaTuru == 3)
                        stokHareket.HareketTipi = 5;

                    stokHareket.StokId = Convert.ToInt32(StokIds[i]);
                    stokHareket.DepoId = DepoId;
                    stokHareket.CariId = CariId;
                    stokHareket.FaturaBaslıkId = faturaBaslık.Id;
                    _stokHarektiRepository.Add(stokHareket);
                }
                catch (Exception ex)
                {

                    res.status = 0;
                    res.message = "Stok Hareketi Oluşturulurken Hata Oluştu. Hata : " + ex.Message;
                    return Json(res);
                }
            }



            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public async Task<IActionResult> DepoAra(string StokAdı, string StokKodu)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            if (!String.IsNullOrEmpty(StokAdı))
            {
                var entities = _depoRepository.GetAllIncluded(o => o.DepoAdı.Contains(StokAdı) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            if (!String.IsNullOrEmpty(StokKodu))
            {
                var düzenlemişKod = KodDüzenle(StokKodu).Item1;
                var entities = _depoRepository.GetAllIncluded(o => o.DepoAdı.Contains(düzenlemişKod) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> KasaAra(string StokAdı, string StokKodu)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            if (!String.IsNullOrEmpty(StokAdı))
            {
                var entities = _kasaRepository.GetAllIncluded(o => o.KasaAdı.Contains(StokAdı) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            if (!String.IsNullOrEmpty(StokKodu))
            {
                var düzenlemişKod = KodDüzenle(StokKodu).Item1;
                var entities = _kasaRepository.GetAllIncluded(o => o.KasaKodu.Contains(düzenlemişKod) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> StokAra(string StokAdı, string StokKodu)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            if (!String.IsNullOrEmpty(StokAdı))
            {
                var entities = _stokRepository.GetAllIncluded(o => o.StokAdı.Contains(StokAdı) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            if (!String.IsNullOrEmpty(StokKodu))
            {
                var düzenlemişKod = KodDüzenle(StokKodu).Item1;
                var entities = _stokRepository.GetAllIncluded(o => o.StokKodu.Contains(düzenlemişKod) && o.ProgramŞirketGrupId == userGroup);
                res.data = entities;
            }
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public async Task<IActionResult> SonFiyatGetir(int StokId)
        {
            JsonResponseModel res = new JsonResponseModel();
            var sonFiyat = _fiyatRepository.GetAll(o => o.StokId == StokId).OrderByDescending(o => o.StokId == StokId).ToList().FirstOrDefault();
            res.data = sonFiyat;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> StokGetir(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var stok = _stokRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            res.data = stok;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> CariSatış(int Id, int FaturaTürü)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            CariSatışViewModel model = new CariSatışViewModel();

            model.Cari = _cariRepository.Get(o => o.Id == Id);
            model.FaturaTürü = FaturaTürü;
            model.DepoKoduTanım = _depoKoduTanımRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup).FirstOrDefault().Tanım;
            model.StokKoduTanım = _stokKoduTanımRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup).OrderBy(o => o.Id).FirstOrDefault().Tanım;
            model.FaturaSeris = _faturaSeriRepository.GetAll(o => o.SeriTürü == FaturaTürü && o.ProgramŞirketGrupId == userGroup);
            return View(model);
        }
        public async Task<IActionResult> YeniÖdemeSeriNoGetir(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            var entities = _ödemeRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup && o.ÖdemeSeriId == Id).ToList();
            var yeniSeriNo = entities.Count() <= 0 ? 0 : entities.Max(o => o.SeriNo);

            res.data = yeniSeriNo + 1;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public async Task<IActionResult> YeniSeriNoGetir(int Id)
        {
            var faturaNo = _faturaSeriRepository.Get(o => o.Id == Id);
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            JsonResponseModel res = new JsonResponseModel();
            var entities = _faturaBaslıkRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup && o.FaturaSeriId == faturaNo.Id).ToList();
            var yeniSeriNo = entities.Count() <= 0 ? 0 : entities.Max(o => o.SeriNo);

            res.data = yeniSeriNo + 1;
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public async Task<IActionResult> CariDetay(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            CariDetayViewModel model = new CariDetayViewModel();
            model.Cari = _cariRepository.Get(o => o.Id == Id);
            model.ÖdemeSeris = _ödemeSeriRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup);
            model.KasaKoduTanım = _kasaKoduTanımRepository.GetAll(o => o.ProgramŞirketGrupId == userGroup).FirstOrDefault().Tanım;

            return View(model);
        }

        public IActionResult Cariler(int ParentId = 0)
        {
            return View(ParentId);
        }

        public async Task<IActionResult> CarilerPagination(int offset, int limit, string search, int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.ParentId == ParentId && o.Tür == 0 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }


        public async Task<IActionResult> CariEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            if (userGroup == null)
            {
                return View("Error");
            }
            CariEditViewModel model = new CariEditViewModel();
            model.Cari = _cariRepository.Get(o => o.ProgramŞirketGrupId == userGroup && o.Id == Id);
            if (model.Cari == null)
            {
                return View("Error");
            }
            if (_cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup) == null)
            {
                return View("/Tanımlar/CariKoduTanım");
            }
            model.CariKodTanım = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup).Tanım;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CariEdit(int Id, string Ad, string Adres, string Kod, string VergiNo)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            entity.CariKodu = Kod;
            entity.VergiNo = VergiNo;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
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
        [HttpGet]
        public async Task<IActionResult> CariAdd(int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            if (_cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup) == null)
            {
                return View("/Tanımlar/CariKoduTanım");
            }

            var kod = _cariRepository.Get(o => o.Id == ParentId);
            CariAddViewModel model = new CariAddViewModel();
            model.CariKodTanım = _cariKoduTanımRepository.Get(o => o.ProgramŞirketGrupId == userGroup).Tanım;
            model.ParentId = ParentId;
            model.CariKodu = kod == null ? null : kod.CariKodu;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CariAdd(string Ad, string Adres, string Kod, string VergiNo, int ParentId = 0)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 0;
            entity.Adres = Adres;
            entity.CariKodu = KodDüzenle(Kod).Item1;
            entity.ParentId = ParentId;
            entity.VergiNo = VergiNo;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Tedarikçiler()
        {


            return View();
        }

        [HttpGet("/Cari/TedarikçiAdd")]
        public IActionResult TedarikçiAdd()
        {
            return View();
        }

        public async Task<IActionResult> TedarikçiAdd(string Ad, string Adres)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 2;
            entity.Adres = Adres;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet("/Cari/TedarikçiEdit")]
        public async Task<IActionResult> TedarikçiEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            var entitiy = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);

            if (entitiy == null)
            {
                return View("/Error");
            }

            return View(entitiy);
        }


        public async Task<IActionResult> TedarikçiEdit(int Id, string Ad, string Adres)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> TedarikçiDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entity = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Belirtilen Uzantı Bulunamadı";
                return Json(res);
            }

            _cariRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);


        }


        public async Task<IActionResult> TedarikçilerPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 2 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }



        public async Task<IActionResult> Müşteriler()
        {

            return View();
        }


        public async Task<IActionResult> MüşteriDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();
            var entity = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Belirtilen Uzantı Bulunamadı";
                return Json(res);
            }

            _cariRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);


        }

        public async Task<IActionResult> MüşterilerPaginaiton(int offset, int limit, string search)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            MüşterilerPaginationViewModel model = new MüşterilerPaginationViewModel();
            model.rows = _cariRepository.GetAllIncludedPagination(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup, offset.ToString(), limit.ToString(), search);
            model.total = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup);
            model.totalNotFiltered = _cariRepository.GetAllIncludedPaginationCount(o => o.Tür == 1 && o.ProgramŞirketGrupId == userGroup);
            return Json(model);
        }
        [HttpGet("/Cari/MüşteriAdd")]
        public IActionResult MüşteriAdd()
        {
            return View();
        }


        public async Task<IActionResult> MüşteriAdd(string Ad, string Adres)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            Cari entity = new Cari();
            entity.Ad = Ad;
            entity.Tür = 1;
            entity.Adres = Adres;
            entity.ProgramŞirketGrupId = userGroup;

            _cariRepository.Add(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet("/Cari/MüşteriEdit")]
        public async Task<IActionResult> MüşteriEdit(int Id)
        {
            var userGroup = await _programŞirketGrupRepository.GetUserGroupId();

            var entitiy = _cariRepository.Get(o => o.Id == Id && o.ProgramŞirketGrupId == userGroup);

            if (entitiy == null)
            {
                return View("/Error");
            }

            return View(entitiy);
        }


        public async Task<IActionResult> MüşteriEdit(int Id, string Ad, string Adres)
        {
            var entity = _cariRepository.Get(o => o.Id == Id);
            entity.Ad = Ad;
            entity.Adres = Adres;
            _cariRepository.Update(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


    }
}
