using Business.Abstract.Services;
using Business.Concrate.Services.Helpers;
using DataAccess.Abstract;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Net;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WebIU.Models.HelperModels;
using WebIU.Models.KareKodViewModels;
using static Entities.Concrete.Contants.Permission;
using static WebIU.Controllers.KareKodController;
namespace WebIU.Controllers
{
    public class KareKodController : Controller
    {
        private readonly DataProcessorService _dataProcessor;
        private readonly IWebSocketService _webSocketHandler;
        private readonly IKareKodUrunlerRepository _kareKodUrunlerRepository;
        private readonly IKareKodAnaUrunRepository _kareKodAnaUrunRepository;
        private readonly IKareKodIsEmriRepository _kareKodIsEmriRepository;
        private readonly IKareKodIstasyonRepository _kareKodIstasyonRepository;
        private readonly IKareKodIsEmriIstasyonMTMRepository _kareKodIsEmriIstasyonMTMRepository;
        private readonly IKareKodBildirimTürüRepository _kareKodBildirimTürüRepository;
        private readonly IKareKodDeaktivasyonTürüRepository _kareKodDeaktivasyonTürüRepository;
        private readonly IKareKodMüşteriRepository _kareKodMüşteriRepository;
        private readonly IKareKodMüşteriYetkilileriRepository _kareKodMüşteriYetkilileriRepository;
        private readonly IKareKodStokRepository _kareKodStokRepository;
        private readonly IKareKodBildirimEmriRepository _kareKodBildirimEmriRepository;
        private readonly IKareKodBildirimStokMTMRepository _kareKodBildirimStokMTMRepository;
        private readonly IKareKodPaletRepository _kareKodPaletRepository;
        private readonly IKareKodKoliRepository _kareKodKoliRepository;
        public KareKodController(DataProcessorService dataProcessor, IWebSocketService webSocketHandler, IKareKodUrunlerRepository kareKodUrunlerRepository, IKareKodAnaUrunRepository
            kareKodAnaUrunRepository, IKareKodIsEmriRepository kareKodIsEmriRepository, IKareKodIstasyonRepository kareKodIstasyonRepository, IKareKodIsEmriIstasyonMTMRepository kareKodIsEmriIstasyonMTMRepository, IKareKodBildirimTürüRepository kareKodBildirimTürüRepository, IKareKodDeaktivasyonTürüRepository kareKodDeaktivasyonTürüRepository, IKareKodMüşteriRepository kareKodMüşteriRepository, IKareKodMüşteriYetkilileriRepository kareKodMüşteriYetkilileriRepository, IKareKodStokRepository kareKodStokRepository, IKareKodBildirimEmriRepository kareKodBildirimEmriRepository, IKareKodBildirimStokMTMRepository kareKodBildirimStokMTMRepository, IKareKodPaletRepository kareKodPaletRepository, IKareKodKoliRepository kareKodKoliRepository)

        {
            _kareKodAnaUrunRepository = kareKodAnaUrunRepository;
            _webSocketHandler = webSocketHandler;
            _dataProcessor = dataProcessor;
            _kareKodUrunlerRepository = kareKodUrunlerRepository;
            _kareKodIsEmriRepository = kareKodIsEmriRepository;
            _kareKodIstasyonRepository = kareKodIstasyonRepository;
            _kareKodIsEmriIstasyonMTMRepository = kareKodIsEmriIstasyonMTMRepository;
            _kareKodBildirimTürüRepository = kareKodBildirimTürüRepository;
            _kareKodDeaktivasyonTürüRepository = kareKodDeaktivasyonTürüRepository;
            _kareKodMüşteriRepository = kareKodMüşteriRepository;
            _kareKodMüşteriYetkilileriRepository = kareKodMüşteriYetkilileriRepository;
            _kareKodStokRepository = kareKodStokRepository;
            _kareKodBildirimEmriRepository = kareKodBildirimEmriRepository;
            _kareKodBildirimStokMTMRepository = kareKodBildirimStokMTMRepository;
            _kareKodPaletRepository = kareKodPaletRepository;
            _kareKodKoliRepository = kareKodKoliRepository;
        }
        public class ÜretimBildirimRequest
        {
            public string dt { get; set; }
            public string mi { get; set; }
            public string pt { get; set; }
            public string gtin { get; set; }
            public string xd { get; set; }
            public string bn { get; set; }
            public string md { get; set; }
            public List<string> snlist { get; set; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class ÜretimBildirimResponseRoot
        {
            public long notificationid { get; set; }
            public string md { get; set; }
            public string gtin { get; set; }
            public string xd { get; set; }
            public string bn { get; set; }
            public List<Snresponselist> snresponselist { get; set; }
        }

        public class Snresponselist
        {
            public string sn { get; set; }
            public string rc { get; set; }
        }
        public class LoginResponse
        {
            public string token { get; set; }
        }


        [XmlRoot(ElementName = "transfer", Namespace = "", IsNullable = false)]
        public class Transfer
        {
            [XmlElement(ElementName = "sourceGLN")]
            public string SourceGLN { get; set; }

            [XmlElement(ElementName = "destinationGLN")]
            public string DestinationGLN { get; set; }

            [XmlElement(ElementName = "actionType")]
            public string ActionType { get; set; }

            [XmlElement(ElementName = "shipTo")]
            public string ShipTo { get; set; }

            [XmlElement(ElementName = "documentNumber")]
            public string DocumentNumber { get; set; }

            [XmlElement(ElementName = "documentDate")]
            public string DocumentDate { get; set; }

            [XmlElement(ElementName = "note")]
            public string Note { get; set; }

            [XmlElement(ElementName = "version")]
            public string Version { get; set; }

            [XmlElement(ElementName = "carrier")]
            public List<Carrier> Carriers { get; set; }
        }

        public class Carrier
        {
            [XmlAttribute(AttributeName = "carrierLabel")]
            public string CarrierLabel { get; set; }

            [XmlAttribute(AttributeName = "containerType")]
            public string ContainerType { get; set; }

            [XmlElement(ElementName = "carrier")]
            public List<Carrier> NestedCarriers { get; set; }

            [XmlElement(ElementName = "productList")]
            public List<ProductList> Products { get; set; }
        }

        public class ProductList
        {
            [XmlAttribute(AttributeName = "GTIN")]
            public string GTIN { get; set; }

            [XmlAttribute(AttributeName = "expirationDate")]
            public string ExpirationDate { get; set; }

            [XmlAttribute(AttributeName = "productionDate")]
            public string ProductionDate { get; set; }

            [XmlAttribute(AttributeName = "lotNumber")]
            public string LotNumber { get; set; }

            [XmlAttribute(AttributeName = "PONumber")]
            public string PONumber { get; set; }

            [XmlElement(ElementName = "serialNumber")]
            public List<string> SerialNumbers { get; set; }
        }

        public class Product
        {
            public string gtin { get; set; }
            public string sn { get; set; }  // Seri Numarası
            public string bn { get; set; }  // Batch Numarası (Parti)
            public string xd { get; set; }  // Son Kullanma Tarihi (Expiration Date)
        }

        public class SatışBldirimiRoot
        {
            public string togln { get; set; }  // Ticari İşletme Numarası
            public List<Product> productList { get; set; }  // Ürün listesi
        }

        public class SatışİptalBldirimiRoot
        {
            public List<Product> productList { get; set; }  // Ürün listesi
        }

        public class SatışBildirimResponseProduct
        {
            public string gtin { get; set; }  // Ürün Kodu (Global Trade Item Number)
            public string sn { get; set; }    // Seri Numarası
            public string uc { get; set; }    // Ünite Kodu (Unit Code)
        }

        public class SatışBildirimResponseRoot
        {
            public long notificationId { get; set; }  // Bildirim ID'si
            public List<SatışBildirimResponseProduct> productList { get; set; }  // Ürün listesi
        }

        public class PtsGöndermeRoot
        {
            public string receiver { get; set; }
            public string file { get; set; }
            public string NotificationUrl { get; set; }
        }

        public class PtsGöndermeResponseRoot
        {
            public long transferId { get; set; }
            public string md5CheckSum { get; set; }
        }


        public class DeaktivasyonRoot
        {
            public string dt { get; set; }
            public string frGln { get; set; }
            public string ds { get; set; }
            public string description { get; set; }
            public Document document { get; set; }
            public List<DeaktivasyonProductList> productList { get; set; }
        }

        public class DeaktivasyonProductList
        {
            public string gtin { get; set; }
            public string sn { get; set; }
            public string bn { get; set; }
            public string xd { get; set; }
        }

        public class Document
        {
            public string dd { get; set; }
            public string dn { get; set; }
        }

        public class KarekodEtiket
        {
            public string Gtin { get; set; }
            public string Sn { get; set; }
            public string Lot { get; set; }
            public string qrCode { get; set; }
            public string Xd { get; set; }
            public string paletSscc { get; set; }
            public string boxSscc { get; set; }
        }

        public IActionResult KarekodDüzelt(int Id)
        {
            var __karekodIsemri = _kareKodIsEmriRepository.Get(o => o.Id == 34);
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == __karekodIsemri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);

            //var bildirimEmri = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            var bildirimstokmtmts = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id).Select(o => o.KareKodStokId);
            var stoks = _kareKodStokRepository.GetAll(o => bildirimstokmtmts.Any(x => x == o.Id));
            var counter = 0;
            foreach (var stok in stoks)
            {
                var oldQr = stok.QrCode;
                var parsedString = ParseString(oldQr);
                parsedString.Item3 = stok.Xd.ToString("yyMMdd");

                var newQr = "01" + parsedString.Item1 + "21" + parsedString.Item2 + "17" + parsedString.Item3 + "10" + parsedString.Item4;

                stok.QrCode = newQr;
                _kareKodStokRepository.Update(stok);

            }


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult KarekodEtitekYazdır(int Id)
        {
            //var __karekodIsemri = _kareKodIsEmriRepository.Get(o => o.Id == 34);
            //var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKkodIstasyonId == 4).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == 2);

            //var bildirimEmri = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            var bildirimstokmtmts = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id).Select(o => o.KareKodStokId);
            var stoks = _kareKodStokRepository.GetAll(o => bildirimstokmtmts.Any(x => x == o.Id));
            var counter = 0;
            foreach (var box in stoks.GroupBy(o => o.BoxSscc))
            {
                foreach (var item in box)
                {
                    try
                    {

                        KarekodEtiket karekodEtiket = new KarekodEtiket();
                        karekodEtiket.Lot = item.Bn;
                        karekodEtiket.Gtin = item.Gtin;
                        karekodEtiket.Xd = item.Xd.ToString("yyMMdd");
                        karekodEtiket.paletSscc = item.PaletSscc;
                        karekodEtiket.boxSscc = item.BoxSscc;
                        karekodEtiket.Sn = item.Sn.ToString().PadLeft(12, '0');

                        var rectusQrString = "01" + karekodEtiket.Gtin + "21" + karekodEtiket.Sn + "17" + karekodEtiket.Xd + "10" + karekodEtiket.Lot;
                        karekodEtiket.qrCode = rectusQrString;
                        counter++;

                        TcpClient client = new TcpClient(Istasyon.IpAdresi, Istasyon.Port); // Sunucu IP ve port
                        NetworkStream stream = client.GetStream();

                        // Gönderilecek mesaj
                        string message = "KAREKOD_ETITEKYAZIR" + Istasyon.IpAdresi + "@" + JsonConvert.SerializeObject(karekodEtiket);
                        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                        stream.Write(messageBuffer, 0, messageBuffer.Length);


                        client.Close();
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }






            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }
        public IActionResult KoliSil(int Id)
        {
            var entity = _kareKodKoliRepository.Get(o => o.Id == Id);
            _kareKodKoliRepository.Delete(entity);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }
        public IActionResult GetProductCount(int Id)
        {
            var x = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WoorId == Id);

            return Json(x);
        }

        public IActionResult GetBildirimÜrünler(int Id)
        {
            var bildirimMtm = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id).Select(o => o.KareKodStokId);
            var uretilmişUrunler = _kareKodStokRepository.GetAll(o => bildirimMtm.Any(x => x == o.Id));
            return Json(uretilmişUrunler);
        }

        public IActionResult BildirimEmriSil(int Id)
        {
            var entity = _kareKodBildirimEmriRepository.Get(o => o.Id == Id);
            _kareKodBildirimEmriRepository.Delete(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult BildirimUrunSil(int Id, int bildirimId)
        {
            var entity = _kareKodBildirimStokMTMRepository.Get(o => o.KareKodStokId == Id && o.KareKodBildirimEmriId == bildirimId);
            _kareKodBildirimStokMTMRepository.Delete(entity, true);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public async Task<IActionResult> BildirimYap(int Id, int pts = 0)
        {
            JsonResponseModel res = new JsonResponseModel();


            var bildirim = _kareKodBildirimEmriRepository.Get(o => o.Id == Id);

            var bildirimMtm = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id).Select(o => o.KareKodStokId);
            var uretilmişUrunler = _kareKodStokRepository.GetAll(o => bildirimMtm.Any(x => x == o.Id));

            if (uretilmişUrunler.Count() != bildirim.Adet)
            {
                res.status = 0;
                res.message = "Lütfen Hedef Adeti Kontrol Edin";
                return Json(res);
            }


            LoginResponse _loginResponse = new LoginResponse();
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(60);

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/token/app/token/"))
                {
                    request.Content = new StringContent("{\n \"username\":\"86813954502160000\",\n \"password\":\"701finS\"\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    // Eğer response başarılıysa, JSON'u deserialize ediyoruz.
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                        _loginResponse = loginResponse;
                    }
                    else
                    {
                        // Hata durumunda uygun hata işlemleri yapılabilir.
                        throw new Exception("İstek başarısız oldu.");
                    }
                }
            }
            if (bildirim.KareKodBildirimTürüId == 1 && pts == 0)
            {
                var uretilmişUrunlerGruop = uretilmişUrunler.GroupBy(o => o.Bn);
                foreach (var item in uretilmişUrunlerGruop)
                {
                    ÜretimBildirimRequest bildirimReuqest = new ÜretimBildirimRequest();
                    bildirimReuqest.dt = "M";
                    bildirimReuqest.mi = "8681395450216";
                    bildirimReuqest.pt = "PP";
                    bildirimReuqest.gtin = item.FirstOrDefault().Gtin;
                    bildirimReuqest.xd = item.FirstOrDefault().Xd.ToString("yyyy-MM-dd");
                    bildirimReuqest.bn = item.FirstOrDefault().Bn;
                    bildirimReuqest.md = item.FirstOrDefault().Md.ToString("yyyy-MM-dd");
                    List<string> sns = new List<string>();
                    foreach (var sn in item)
                    {
                        sns.Add(sn.Sn.ToString().PadLeft(12, '0'));
                    }
                    bildirimReuqest.snlist = sns;

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromMinutes(60);
                        using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/product/app/supplynotification/"))
                        {
                            request.Headers.Add("Authorization", "Bearer " + _loginResponse.token);

                            request.Content = new StringContent(JsonConvert.SerializeObject(bildirimReuqest));
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                            var response = await httpClient.SendAsync(request);
                            var _jsonResponse = await response.Content.ReadAsStringAsync();

                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = await response.Content.ReadAsStringAsync();
                                var üretimbildirimResponse = JsonConvert.DeserializeObject<ÜretimBildirimResponseRoot>(jsonResponse);

                                foreach (var üretimBildirim in üretimbildirimResponse.snresponselist)
                                {
                                    var enttiy = _kareKodStokRepository.Get(o => o.Sn == Convert.ToInt64(üretimBildirim.sn) && o.Bn == bildirimReuqest.bn);
                                    if (üretimBildirim.rc == "00000")
                                    {
                                        enttiy.NotificationStatus = 1;
                                        enttiy.InStock = 1;
                                    }
                                    if (üretimBildirim.rc == "10007")
                                    {
                                        enttiy.NotificationStatus = 1;
                                        enttiy.InStock = 1;
                                    }
                                    else
                                    {
                                        enttiy.NotificationStatus = 0;
                                        enttiy.InStock = 1;
                                    }
                                    _kareKodStokRepository.Update(enttiy);
                                }
                                bildirim.BildirimDurumu = 1;
                                bildirim.Açıklama = bildirim.Açıklama + " Bildirim Id: " + üretimbildirimResponse.notificationid.ToString() + " Bildirilen Ürün : " + üretimbildirimResponse.snresponselist.Where(o => o.rc == "00000" || o.rc == "10007").Count();
                                _kareKodBildirimEmriRepository.Update(bildirim);
                            }
                            else
                            {
                                // Hata durumunda uygun hata işlemleri yapılabilir.
                                throw new Exception("İstek başarısız oldu.");
                            }
                        }
                    }

                }

            }
            List<Carrier> carrires = new List<Carrier>();
            if (bildirim.KareKodBildirimTürüId == 2 && pts == 0)
            {
                var müşteri = _kareKodMüşteriRepository.Get(o => o.Id == bildirim.KareKodMüşteriId);

                var bildirimReuqest = new SatışBldirimiRoot();
                bildirimReuqest.togln = müşteri.ToGLN;
                bildirimReuqest.productList = new List<Product>();
                foreach (var item in uretilmişUrunler)
                {
                    bildirimReuqest.productList.Add(new Product()
                    {
                        gtin = item.Gtin,
                        sn = item.Sn.ToString().PadLeft(12, '0'),
                        bn = item.Bn,
                        xd = item.Xd.ToString("yyyy-MM-dd")
                    });
                }
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(60);

                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/wholesale/app/dispatch/"))
                    {
                        try
                        {
                            request.Headers.Add("Authorization", "Bearer " + _loginResponse.token);
                            var cntt = JsonConvert.SerializeObject(bildirimReuqest);
                            request.Content = new StringContent(cntt);
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                            var response = await httpClient.SendAsync(request);
                            var _jsonResponse = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = await response.Content.ReadAsStringAsync();
                                var üretimbildirimResponse = JsonConvert.DeserializeObject<SatışBildirimResponseRoot>(jsonResponse);

                                foreach (var üretimBildirim in üretimbildirimResponse.productList)
                                {
                                    var enttiy = _kareKodStokRepository.Get(o => o.Sn == Convert.ToInt64(üretimBildirim.sn));
                                    if (üretimBildirim.uc == "00000")
                                    {
                                        enttiy.NotificationStatus = 1;
                                        enttiy.InStock = 0;
                                    }
                                    else
                                    {
                                        enttiy.NotificationStatus = 0;
                                        enttiy.InStock = 1;
                                    }
                                    _kareKodStokRepository.Update(enttiy);
                                }
                                bildirim.BildirimDurumu = 1;


                                bildirim.Açıklama = bildirim.Açıklama + " Bildirim Id: " + üretimbildirimResponse.notificationId.ToString() + " Bildirilen Ürün : " + üretimbildirimResponse.productList.Where(o => o.uc == "00000").Count();
                                _kareKodBildirimEmriRepository.Update(bildirim);
                            }
                            else
                            {
                                // Hata durumunda uygun hata işlemleri yapılabilir.
                                throw new Exception("İstek başarısız oldu.");
                            }
                        }
                        catch (Exception ex)
                        {

                            bildirim.Açıklama = bildirim.Açıklama + "Satış Bildirimi Yapılırken Hata Oluştur : " + ex.Message;
                            _kareKodBildirimEmriRepository.Update(bildirim);
                        }


                    }
                }
            }
            if (bildirim.KareKodBildirimTürüId == 3 && pts == 0)
            {
                var müşteri = _kareKodMüşteriRepository.Get(o => o.Id == bildirim.KareKodMüşteriId);

                var bildirimReuqest = new SatışİptalBldirimiRoot();
                bildirimReuqest.productList = new List<Product>();
                foreach (var item in uretilmişUrunler)
                {
                    bildirimReuqest.productList.Add(new Product()
                    {
                        gtin = item.Gtin,
                        sn = item.Sn.ToString().PadLeft(12, '0'),
                        bn = item.Bn,
                        xd = item.Xd.ToString("yyyy-MM-dd")
                    });
                }
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(60);

                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/wholesale/app/dispatchcancel/"))
                    {
                        try
                        {
                            request.Headers.Add("Authorization", "Bearer " + _loginResponse.token);
                            var cntt = JsonConvert.SerializeObject(bildirimReuqest);
                            request.Content = new StringContent(cntt);
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                            var response = await httpClient.SendAsync(request);
                            var _jsonResponse = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = await response.Content.ReadAsStringAsync();
                                var üretimbildirimResponse = JsonConvert.DeserializeObject<SatışBildirimResponseRoot>(jsonResponse);

                                foreach (var üretimBildirim in üretimbildirimResponse.productList)
                                {
                                    var enttiy = _kareKodStokRepository.Get(o => o.Sn == Convert.ToInt64(üretimBildirim.sn));
                                    if (üretimBildirim.uc == "00000")
                                    {
                                        enttiy.NotificationStatus = 1;
                                        enttiy.InStock = 1;
                                    }
                                    else
                                    {
                                        enttiy.NotificationStatus = 0;
                                        enttiy.InStock = 0;
                                    }
                                    _kareKodStokRepository.Update(enttiy);
                                }
                                bildirim.BildirimDurumu = 1;


                                bildirim.Açıklama = bildirim.Açıklama + " Bildirim Id: " + üretimbildirimResponse.notificationId.ToString() + " Bildirilen Ürün : " + üretimbildirimResponse.productList.Where(o => o.uc == "00000").Count();
                                _kareKodBildirimEmriRepository.Update(bildirim);
                            }
                            else
                            {
                                // Hata durumunda uygun hata işlemleri yapılabilir.
                                throw new Exception("İstek başarısız oldu.");
                            }
                        }
                        catch (Exception ex)
                        {

                            bildirim.Açıklama = bildirim.Açıklama + "Satış Bildirimi Yapılırken Hata Oluştur : " + ex.Message;
                            _kareKodBildirimEmriRepository.Update(bildirim);
                        }


                    }
                }
            }
            if (bildirim.KareKodBildirimTürüId == 6 && pts == 0)
            {
                var müşteri = _kareKodMüşteriRepository.Get(o => o.Id == bildirim.KareKodMüşteriId);

                var bildirimReuqest = new DeaktivasyonRoot();
                bildirimReuqest.frGln = "8681395450216";
                bildirimReuqest.dt = "D";
                var deaktivaston = _kareKodDeaktivasyonTürüRepository.Get(o => o.Id == bildirim.KareKodDeaktivasyonTürüId);
                bildirimReuqest.ds = deaktivaston.DeaktivasyonKodu;
                bildirimReuqest.document = new Document();
                bildirimReuqest.document.dn = bildirim.DökümanTarihi?.ToString("yyyy-MM-dd");
                bildirimReuqest.document.dn = bildirim.DökümanNo;
                bildirimReuqest.description = bildirim.Açıklama;

                bildirimReuqest.productList = new List<DeaktivasyonProductList>();
                foreach (var item in uretilmişUrunler)
                {
                    bildirimReuqest.productList.Add(new DeaktivasyonProductList()
                    {
                        gtin = item.Gtin,
                        sn = item.Sn.ToString().PadLeft(12, '0'),
                        bn = item.Bn,
                        xd = item.Xd.ToString("yyyy-MM-dd")
                    });
                }
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(60);

                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/common/app/deactivation/"))
                    {
                        try
                        {
                            request.Headers.Add("Authorization", "Bearer " + _loginResponse.token);
                            var cntt = JsonConvert.SerializeObject(bildirimReuqest);
                            request.Content = new StringContent(cntt);
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                            var response = await httpClient.SendAsync(request);
                            var _jsonResponse = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonResponse = await response.Content.ReadAsStringAsync();
                                var üretimbildirimResponse = JsonConvert.DeserializeObject<SatışBildirimResponseRoot>(jsonResponse);

                                foreach (var üretimBildirim in üretimbildirimResponse.productList)
                                {
                                    var enttiy = _kareKodStokRepository.Get(o => o.Sn == Convert.ToInt64(üretimBildirim.sn));
                                    if (üretimBildirim.uc == "00000")
                                    {
                                        enttiy.NotificationStatus = 1;
                                        enttiy.InStock = 0;
                                    }
                                    else
                                    {
                                        enttiy.NotificationStatus = 0;
                                        enttiy.InStock = 0;
                                    }
                                    _kareKodStokRepository.Update(enttiy);
                                }
                                bildirim.BildirimDurumu = 1;


                                bildirim.Açıklama = bildirim.Açıklama + " Bildirim Id: " + üretimbildirimResponse.notificationId.ToString() + " Bildirilen Ürün : " + üretimbildirimResponse.productList.Where(o => o.uc == "00000").Count();
                                _kareKodBildirimEmriRepository.Update(bildirim);
                            }
                            else
                            {
                                // Hata durumunda uygun hata işlemleri yapılabilir.
                                throw new Exception("İstek başarısız oldu.");
                            }
                        }
                        catch (Exception ex)
                        {

                            bildirim.Açıklama = bildirim.Açıklama + "Satış Bildirimi Yapılırken Hata Oluştur : " + ex.Message;
                            _kareKodBildirimEmriRepository.Update(bildirim);
                        }


                    }
                }
            }
            if (pts == 2)
            {
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Transfer Nesnesi Oluşturulıyor";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var müşteri = _kareKodMüşteriRepository.Get(o => o.Id == bildirim.KareKodMüşteriId);
                var paletGroup = uretilmişUrunler.GroupBy(o => o.PaletSscc);
                var carriers = new List<Carrier>();
                foreach (var palet in paletGroup)
                {
                    var carrier = new Carrier
                    {
                        CarrierLabel = palet.Key, // PaletSscc CarrierLabel olarak kullanılıyor
                        ContainerType = "P",      // Palet olduğu için "P" tipi
                        //Products = new List<ProductList>(),
                        NestedCarriers = new List<Carrier>()
                    };

                    // Ürünleri GTIN'e göre gruplandırıp ProductList oluştur
                    var productGroups = palet.GroupBy(p => p.BoxSscc);

                    foreach (var productGroup in productGroups)
                    {
                        var firstProduct = productGroup.First();
                        var nestedcarries = new Carrier
                        {
                            CarrierLabel = productGroup.Key,
                            ContainerType = "C",
                            Products = new List<ProductList>(),
                        };
                        var productList = new ProductList
                        {
                            GTIN = firstProduct.Gtin,
                            ExpirationDate = firstProduct.Xd.ToString("yyyy-MM-dd"),
                            ProductionDate = firstProduct.Md.ToString("yyyy-MM-dd"),
                            LotNumber = firstProduct.Bn,
                            PONumber = "", // Eğer PONumber varsa buraya eklenebilir
                            SerialNumbers = productGroup.Select(p => p.Sn.ToString().PadLeft(12, '0')).ToList()
                        };

                        // ProductList'i paletin Carrier'ine ekle
                        nestedcarries.Products.Add(productList);


                        carrier.NestedCarriers.Add(nestedcarries);

                    }

                    // Carrier'ı listeye ekle
                    carriers.Add(carrier);
                }
                var transfer = new Transfer
                {
                    SourceGLN = "8681395450216",
                    DestinationGLN = müşteri.ToGLN,
                    ActionType = "S",
                    ShipTo = müşteri.GLN,
                    DocumentNumber = bildirim.DökümanNo,
                    DocumentDate = bildirim.DökümanTarihi?.ToString("yyyy-MM-dd"),
                    Note = "PTS Bildirimi",
                    Version = "1.4",
                    Carriers = carriers
                };
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Transfer Nesnesi Oluşturuldu";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var serializer = new XmlSerializer(typeof(Transfer));
                var xmlSerializer = new XmlSerializer(typeof(Transfer)); // YourClass yerine sınıfını koy
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Zip Dosyası Oluşturuluyor";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var settings = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false), // UTF-8 encoding ayarla
                    Indent = true, // Düzgün okunabilirlik için XML'i girintile
                    OmitXmlDeclaration = true // XML bildirimini kaldır
                };
                // XML'i string olarak oluştur
                string xmlContent;
                using (var stringWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        xmlSerializer.Serialize(xmlWriter, transfer);
                        xmlContent = stringWriter.ToString();
                    }
                }
                // XML'i PTS adında bir dosya olarak kaydet
                string xmlFilePath = "PTS.xml";
                System.IO.File.WriteAllText(xmlFilePath, xmlContent);

                // Dosyayı zip haline getir
                string zipFilePath = "PTS.zip";
                using (var zipStream = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
                    {
                        var zipEntry = archive.CreateEntry(System.IO.Path.GetFileName(xmlFilePath));
                        using (var entryStream = zipEntry.Open())
                        {
                            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                fileStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Zip Dosyası Oluşturuldu";
                _kareKodBildirimEmriRepository.Update(bildirim);

                // Zip dosyasını base64'e çevir
                byte[] zipBytes = System.IO.File.ReadAllBytes(zipFilePath);
                string base64Zip = Convert.ToBase64String(zipBytes);


                var bildirimReuqest = new PtsGöndermeRoot()
                {
                    receiver = müşteri.ToGLN,
                    file = base64Zip
                };


                bildirim.Açıklama += "\n-> E-posta Gönderimi Başladı ";
                _kareKodBildirimEmriRepository.Update(bildirim);
                // Zip dosyasını e-posta ile gönder
                try
                {
                    // Attachment oluştur
                    Attachment zipAttachment = new Attachment(zipFilePath);

                    // Alıcı listesi (gerçek alıcı e-postaları ile değiştirin)
                    var yetkililer = _kareKodMüşteriYetkilileriRepository.GetAll(o => o.KareKodMüşteriId == müşteri.Id).Select(o => o.Email).ToList();
                    List<string> recipients = yetkililer;


                    var urun = _kareKodAnaUrunRepository.Get(o => o.Gtin == uretilmişUrunler.FirstOrDefault().Gtin);
                    // HTML içerikleri
                    string emailContentTurkish = $@"
                    <p>Merhaba Sayın yetkili,</p>
                        <p>EdisPharma tarafından {uretilmişUrunler.Count()} adet <b>{urun.Name + " " + urun.Unit}</b> adlı üründen tarafınıza 
                        gönderilmiştir.</p>
                    ";

                    // HTML görünümü oluştur
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(emailContentTurkish, Encoding.UTF8, "text/html");

                    // Mail gönderme fonksiyonunu çağır
                    SendMailForPTS(htmlView, recipients, zipAttachment);

                    // Bildirim açıklamasını güncelle
                    bildirim.Açıklama += "\n-> E-posta gönderildi";
                    _kareKodBildirimEmriRepository.Update(bildirim);
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    bildirim.Açıklama += "\n-> E-posta gönderiminde hata oluştu: " + ex.Message;
                    _kareKodBildirimEmriRepository.Update(bildirim);
                }








                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Pts Gönderildi";
                _kareKodBildirimEmriRepository.Update(bildirim);
            }
            if (pts == 1)
            {
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Transfer Nesnesi Oluşturulıyor";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var müşteri = _kareKodMüşteriRepository.Get(o => o.Id == bildirim.KareKodMüşteriId);
                var paletGroup = uretilmişUrunler.GroupBy(o => o.PaletSscc);
                var carriers = new List<Carrier>();
                foreach (var palet in paletGroup)
                {
                    var carrier = new Carrier
                    {
                        CarrierLabel = palet.Key, // PaletSscc CarrierLabel olarak kullanılıyor
                        ContainerType = "P",      // Palet olduğu için "P" tipi
                        //Products = new List<ProductList>(),
                        NestedCarriers = new List<Carrier>()
                    };

                    // Ürünleri GTIN'e göre gruplandırıp ProductList oluştur
                    var productGroups = palet.GroupBy(p => p.BoxSscc);

                    foreach (var productGroup in productGroups)
                    {
                        var firstProduct = productGroup.First();
                        var nestedcarries = new Carrier
                        {
                            CarrierLabel = productGroup.Key,
                            ContainerType = "C",
                            Products = new List<ProductList>(),
                        };
                        var productList = new ProductList
                        {
                            GTIN = firstProduct.Gtin,
                            ExpirationDate = firstProduct.Xd.ToString("yyyy-MM-dd"),
                            ProductionDate = firstProduct.Md.ToString("yyyy-MM-dd"),
                            LotNumber = firstProduct.Bn,
                            PONumber = "", // Eğer PONumber varsa buraya eklenebilir
                            SerialNumbers = productGroup.Select(p => p.Sn.ToString().PadLeft(12, '0')).ToList()
                        };
                        // ProductList'i paletin Carrier'ine ekle
                        nestedcarries.Products.Add(productList);


                        carrier.NestedCarriers.Add(nestedcarries);

                    }

                    // Carrier'ı listeye ekle
                    carriers.Add(carrier);
                }
                var transfer = new Transfer
                {
                    SourceGLN = "8681395450216",
                    DestinationGLN = müşteri.ToGLN,
                    ActionType = "S",
                    ShipTo = müşteri.GLN,
                    DocumentNumber = bildirim.DökümanNo,
                    DocumentDate = bildirim.DökümanTarihi?.ToString("yyyy-MM-dd"),
                    Note = "PTS Bildirimi",
                    Version = "1.4",
                    Carriers = carriers
                };
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Transfer Nesnesi Oluşturuldu";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var serializer = new XmlSerializer(typeof(Transfer));
                var xmlSerializer = new XmlSerializer(typeof(Transfer)); // YourClass yerine sınıfını koy
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Zip Dosyası Oluşturuluyor";
                _kareKodBildirimEmriRepository.Update(bildirim);
                var settings = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false), // UTF-8 encoding ayarla
                    Indent = true, // Düzgün okunabilirlik için XML'i girintile
                    OmitXmlDeclaration = true // XML bildirimini kaldır
                };
                // XML'i string olarak oluştur
                string xmlContent;
                using (var stringWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        xmlSerializer.Serialize(xmlWriter, transfer);
                        xmlContent = stringWriter.ToString();
                    }
                }
                // XML'i PTS adında bir dosya olarak kaydet
                string xmlFilePath = "PTS.xml";
                System.IO.File.WriteAllText(xmlFilePath, xmlContent);

                // Dosyayı zip haline getir
                string zipFilePath = "PTS.zip";
                using (var zipStream = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (var archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
                    {
                        var zipEntry = archive.CreateEntry(System.IO.Path.GetFileName(xmlFilePath));
                        using (var entryStream = zipEntry.Open())
                        {
                            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
                            {
                                fileStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Zip Dosyası Oluşturuldu";
                _kareKodBildirimEmriRepository.Update(bildirim);

                // Zip dosyasını base64'e çevir
                byte[] zipBytes = System.IO.File.ReadAllBytes(zipFilePath);
                string base64Zip = Convert.ToBase64String(zipBytes);


                var bildirimReuqest = new PtsGöndermeRoot()
                {
                    receiver = müşteri.ToGLN,
                    file = base64Zip
                };



                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Pts Gönderiliyor";
                _kareKodBildirimEmriRepository.Update(bildirim);
                PtsGöndermeResponseRoot üretimbildirimResponse = null;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://its2.saglik.gov.tr/pts/app/SendPackage"))
                    {
                        request.Headers.Add("Authorization", "Bearer " + _loginResponse.token);
                        var cntt = JsonConvert.SerializeObject(bildirimReuqest);
                        request.Content = new StringContent(cntt);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Pts Send Endpoint Start";
                        _kareKodBildirimEmriRepository.Update(bildirim);
                        var _jsonResponse = await response.Content.ReadAsStringAsync();
                        bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Pts End Endpoint Start -> \n" + _jsonResponse;
                        _kareKodBildirimEmriRepository.Update(bildirim);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            üretimbildirimResponse = JsonConvert.DeserializeObject<PtsGöndermeResponseRoot>(jsonResponse);


                            bildirim.BildirimDurumu = 1;
                            bildirim.Açıklama = bildirim.Açıklama + "\n PTS NO: " + üretimbildirimResponse.transferId + "\n MD5: " + üretimbildirimResponse.md5CheckSum;
                            _kareKodBildirimEmriRepository.Update(bildirim);
                        }
                        else
                        {
                            // Hata durumunda uygun hata işlemleri yapılabilir.
                            throw new Exception("İstek başarısız oldu.");
                        }
                    }
                }

                bildirim.Açıklama = bildirim.Açıklama + "\n->" + "Pts Gönderildi";
                _kareKodBildirimEmriRepository.Update(bildirim);

                bildirim.Açıklama += "\n-> E-posta Gönderimi Başladı ";
                _kareKodBildirimEmriRepository.Update(bildirim);
                // Zip dosyasını e-posta ile gönder
                try
                {
                    // Attachment oluştur
                    Attachment zipAttachment = new Attachment(zipFilePath);

                    // Alıcı listesi (gerçek alıcı e-postaları ile değiştirin)
                    var yetkililer = _kareKodMüşteriYetkilileriRepository.GetAll(o => o.KareKodMüşteriId == müşteri.Id).Select(o => o.Email).ToList();
                    List<string> recipients = yetkililer;


                    var urun = _kareKodAnaUrunRepository.Get(o => o.Gtin == uretilmişUrunler.FirstOrDefault().Gtin);
                    // HTML içerikleri
                    string emailContentTurkish = $@"
                    <p>Merhaba Sayın yetkili,</p>
                        <p>EdisPharma tarafından {uretilmişUrunler.Count()} adet <b>{urun.Name + " " + urun.Unit}</b> adlı üründen tarafınıza 
                        <b>{üretimbildirimResponse.transferId}</b> pts döküman numarası ile gönderilmiştir.</p>
                    ";

                    // HTML görünümü oluştur
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(emailContentTurkish, Encoding.UTF8, "text/html");

                    // Mail gönderme fonksiyonunu çağır
                    SendMailForPTS(htmlView, recipients, zipAttachment);

                    // Bildirim açıklamasını güncelle
                    bildirim.Açıklama += "\n-> E-posta gönderildi";
                    _kareKodBildirimEmriRepository.Update(bildirim);
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    bildirim.Açıklama += "\n-> E-posta gönderiminde hata oluştu: " + ex.Message;
                    _kareKodBildirimEmriRepository.Update(bildirim);
                }








            }















            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        private static void SendMailForPTS(AlternateView htmlView, List<string> recipients, Attachment attachment = null)
        {
            // SMTP ve mail bilgileri
            string smtpHost = "mail.edispharma.com.tr";
            int smtpPort = 587;
            string smtpUsername = "pts@edispharma.com.tr";
            string smtpPassword = "Mehmet_123";
            string fromEmail = "pts@edispharma.com.tr";
            string fromName = "Edis Pharma";

            // Sistem dili Türkçe değilse, İngilizce başlık kullan
            string subject = "PTS Bildirimi";

            try
            {
                // SMTP ayarları
                using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    // Mail mesajı oluşturma
                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress(fromEmail, fromName);
                        message.Subject = subject;
                        message.IsBodyHtml = true;

                        // Alıcıları ekle
                        recipients.ForEach(recipient => message.To.Add(recipient));

                        // Varsa dosya eki ekle
                        if (attachment != null)
                        {
                            message.Attachments.Add(attachment);
                        }
                        message.CC.Add("mehmetbozkr3@gmail.com");
                        // Alternatif görünümü ekle
                        message.AlternateViews.Add(htmlView);

                        // Maili gönder
                        smtpClient.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                throw;
            }
        }
        public IActionResult KareKodDeğiştir(int Id, string qrKod)
        {
            JsonResponseModel res = new JsonResponseModel();
            var oldEntitiy = _kareKodUrunlerRepository.Get(o => o.Id == Id);
            var existsCheck = _kareKodUrunlerRepository.GetAll(o => o.QrCode == qrKod);
            if (existsCheck.Count() >= 1)
            {
                res.status = 0;
                res.message = "Mükerrer Ürün Bulundu";
                return Json(res);
            }
            var x = ParseString(qrKod);
            oldEntitiy.QrCode = qrKod;
            oldEntitiy.Sn = Convert.ToInt64(x.Item2);
            _kareKodUrunlerRepository.Update(oldEntitiy);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult Koliİçerik(int Id)
        {
            var koli = _kareKodKoliRepository.Get(o => o.Id == Id);
            var içerikelr = _kareKodUrunlerRepository.GetAll(o => o.BoxSn == koli.SeriNo);
            return View(içerikelr);
        }

        public IActionResult Paletler(int Id)
        {
            var koli = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            var içerikelr = _kareKodPaletRepository.GetAll(o => o.KareKodIsEmriId == koli.Id);
            return View(içerikelr);
        }

        public IActionResult Koliler(int Id)
        {
            var koli = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            var içerikelr = _kareKodKoliRepository.GetAll(o => o.KareKodIsEmriId == koli.Id);
            return View(içerikelr);
        }


        public IActionResult PaletSSCCYadır(int PaletId, int IsEmriıd)
        {

            var __karekodIsemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriıd);
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == __karekodIsemri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);

            var palet = _kareKodPaletRepository.Get(o => o.Id == PaletId);


            PaletEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, __karekodIsemri.Id, palet.SSCC, palet.SeriNo.ToString());

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult TümYeniSSCCYazır(int PaletId, int IsEmriıd)
        {
            var eskiPlalet = _kareKodPaletRepository.Get(o => o.Id == PaletId);
            var sonPalet = _kareKodPaletRepository.GetMax();


            var __karekodIsemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriıd);
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == __karekodIsemri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);


            KareKodPalet yeniPalet = new KareKodPalet();
            yeniPalet.SSCC = SSCC("0", sonPalet.SeriNo + 1);
            yeniPalet.SeriNo = sonPalet.SeriNo + 1;
            yeniPalet.KareKodIsEmriId = IsEmriıd;
            yeniPalet.AddedDate = DateTime.Now;

            var yeniPaletEntity = _kareKodPaletRepository.Add(yeniPalet);
            PaletEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, __karekodIsemri.Id, yeniPalet.SSCC, eskiPlalet.SeriNo.ToString(), eskiPlalet.SSCC);
            var paletİçindekiKoliler = _kareKodKoliRepository.GetAll(o => o.PaletSeriNo == eskiPlalet.SeriNo);

            foreach (var item in paletİçindekiKoliler)
            {
                var koliİçindekiUrunler = _kareKodUrunlerRepository.GetAll(o => o.BoxSn == item.SeriNo);
                var SonKoliSn = _kareKodKoliRepository.GetMax();
                var eskisscc = item.SSCC;
                item.PaletSeriNo = yeniPaletEntity.SeriNo;
                item.SeriNo = SonKoliSn.SeriNo + 1;
                item.SSCC = SSCC("1", SonKoliSn.SeriNo + 1);
                _kareKodKoliRepository.Update(item);
                foreach (var urun in koliİçindekiUrunler)
                {
                    urun.BoxSn = item.SeriNo;
                    urun.BoxSscc = item.SSCC;
                    urun.PaletSscc = yeniPalet.SSCC;
                    urun.PaletSn = yeniPalet.SeriNo;

                    _kareKodUrunlerRepository.Update(urun);
                }
                KoliEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, item.SSCC, __karekodIsemri.Id, koliİçindekiUrunler.Count(), eskisscc);
            }
            _kareKodPaletRepository.Delete(eskiPlalet);
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult KoliSSCCYadır(int KoliId, int IsEmriıd)
        {

            var __karekodIsemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriıd);
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == __karekodIsemri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);

            var koli = _kareKodKoliRepository.Get(o => o.Id == KoliId);
            var koliİçindekiÜrünSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.BoxSn == koli.SeriNo);


            KoliEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, koli.SSCC.ToString(), __karekodIsemri.Id, koliİçindekiÜrünSayısı);

            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        public IActionResult BildirimEmriİçerikDüzenle(int Id)
        {
            KareKodBildirimEmri model = new KareKodBildirimEmri();
            model = _kareKodBildirimEmriRepository.Get(o => o.Id == Id);
            return View(model);
        }


        public IActionResult BildirimİçeriğiPagination(int offset, int limit, string search, int Id)
        {
            var Uruns = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id).Select(o => o.KareKodStokId);

            BildirimİçeriğiPaginationModel model = new BildirimİçeriğiPaginationModel();
            model.rows = _kareKodStokRepository.GetAllIncludedPagination(o => Uruns.Any(x => x == o.Id), offset.ToString(), limit.ToString(), search);
            model.total = _kareKodStokRepository.GetAllIncludedPaginationCount(o => Uruns.Any(x => x == o.Id), offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodStokRepository.GetAllIncludedPaginationCount(o => Uruns.Any(x => x == o.Id), offset.ToString(), limit.ToString(), search);
            return Json(model);
        }
        public IActionResult BildirimEmriİçerikEkle2(List<string> Aranacakİçerik, int Id)
        {

            List<string> yeniAranacakİçerik = new List<string>();
            if (Aranacakİçerik.Count() >= 1)
            {
                if (Aranacakİçerik.FirstOrDefault().Length > 50)
                {
                    foreach (var item in Aranacakİçerik.FirstOrDefault().Split(","))
                    {
                        yeniAranacakİçerik.Add(item.Trim().Trim(','));
                    }
                    Aranacakİçerik = yeniAranacakİçerik;
                }
            }

            // Veriyi liste olarak tanımlıyoruz.
            List<string> dataList = new List<string>
            {
            };
            dataList = Aranacakİçerik;
            // Tekrar edenleri bulmak için HashSet ve liste tanımlıyoruz.
            HashSet<string> uniqueItems = new HashSet<string>();
            List<string> duplicateItems = new List<string>();

            // Her satırı kontrol ediyoruz.
            foreach (var item in dataList)
            {
                // HashSet'e ekleyemezsek, duplicateItems'a ekliyoruz.
                if (!uniqueItems.Add(item))
                {
                    duplicateItems.Add(item);
                }
            }

            // Tekrar eden satırları ekrana yazdırıyoruz.
            if (duplicateItems.Count > 0)
            {
                Console.WriteLine("Tekrar eden satırlar:");
                foreach (var duplicate in duplicateItems)
                {
                    Console.WriteLine(duplicate);
                }
            }
            else
            {
                Console.WriteLine("Tekrar eden satır yok.");
            }




            List<KareKodBildirimStokMTM> stokMtms = new List<KareKodBildirimStokMTM>();
            var bildirimEmri = _kareKodBildirimEmriRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            var x = Aranacakİçerik;
            foreach (var item in Aranacakİçerik)
            {
                string str = item;
                string firstThreeChars = str.Substring(0, 3);
                int result = int.Parse(firstThreeChars);
                if (item.Length == 48)
                {
                    KareKodStok bulunanİçerik = new KareKodStok();
                    bulunanİçerik = _kareKodStokRepository.Get(o => o.QrCode == item);
                    if (bulunanİçerik == null)
                    {
                        var oldQr = item;
                        var parsedString = ParseString(oldQr);
                        //parsedString.Item3 = item.Xd.ToString("yyMMdd");
                        //var newQr = "01" + parsedString.Item1 + "21" + parsedString.Item2 + "17" + parsedString.Item3 + "10" + parsedString.Item4;
                        bulunanİçerik = _kareKodStokRepository.Get(o => o.Sn == Convert.ToInt64(parsedString.Item2.Trim()));
                    }

                    KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                    entity.KareKodStokId = bulunanİçerik.Id;
                    entity.KareKodBildirimEmriId = Id;
                    entity.BildirimDurumu = 0;
                    entity.AddedDate = DateTime.Now;
                    stokMtms.Add(entity);
                    //_kareKodBildirimStokMTMRepository.Add(entity);
                }
                else if (item.Length == 8)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.Gtin == bildirimEmri.KareKodAnaUrun.Gtin && o.Bn == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.AddedDate = DateTime.Now;
                        entity.BildirimDurumu = 0;
                        stokMtms.Add(entity);
                    }
                }
                else if (result == 0)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.PaletSscc == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.BildirimDurumu = 0;
                        entity.AddedDate = DateTime.Now;

                        stokMtms.Add(entity);
                    }
                }
                else if (result == 1)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.BoxSscc == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.AddedDate = DateTime.Now;

                        entity.BildirimDurumu = 0;
                        stokMtms.Add(entity);
                    }
                }
                else
                {

                }
            }
            var alredyExistsStoks = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id);

            stokMtms = stokMtms.DistinctBy(o => o.KareKodStokId).ToList();
            foreach (var item in stokMtms)
            {
                var flag = true;
                foreach (var alredyexits in alredyExistsStoks)
                {
                    if (alredyexits.KareKodStokId == item.KareKodStokId)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                {
                    continue;
                }
                item.AddedDate = DateTime.Now;
                _kareKodBildirimStokMTMRepository.Add(item);
            }


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult BildirimEmriİçerikEkle(List<string> Aranacakİçerik, int Id)
        {
            List<KareKodBildirimStokMTM> stokMtms = new List<KareKodBildirimStokMTM>();
            var bildirimEmri = _kareKodBildirimEmriRepository.GetAllIncluded(o => o.Id == Id).FirstOrDefault();
            var x = Aranacakİçerik;
            foreach (var item in Aranacakİçerik)
            {
                string str = item;
                string firstThreeChars = str.Substring(0, 3);
                int result = int.Parse(firstThreeChars);
                if (item.Length == 48)
                {
                    var bulunanİçerik = _kareKodStokRepository.Get(o => o.QrCode == item);
                    KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                    entity.KareKodStokId = bulunanİçerik.Id;
                    entity.KareKodBildirimEmriId = Id;
                    entity.BildirimDurumu = 0;
                    entity.AddedDate = DateTime.Now;
                    stokMtms.Add(entity);
                    //_kareKodBildirimStokMTMRepository.Add(entity);
                }
                else if (item.Length == 8)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.Gtin == bildirimEmri.KareKodAnaUrun.Gtin && o.Bn == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.AddedDate = DateTime.Now;
                        entity.BildirimDurumu = 0;
                        stokMtms.Add(entity);
                    }
                }
                else if (result == 0)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.PaletSscc == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.BildirimDurumu = 0;
                        entity.AddedDate = DateTime.Now;

                        stokMtms.Add(entity);
                    }
                }
                else if (result == 1)
                {
                    var bulunanİçerik = _kareKodStokRepository.GetAll(o => o.BoxSscc == item);
                    foreach (var içerik in bulunanİçerik)
                    {
                        KareKodBildirimStokMTM entity = new KareKodBildirimStokMTM();
                        entity.KareKodStokId = içerik.Id;
                        entity.KareKodBildirimEmriId = Id;
                        entity.AddedDate = DateTime.Now;

                        entity.BildirimDurumu = 0;
                        stokMtms.Add(entity);
                    }
                }
            }
            var alredyExistsStoks = _kareKodBildirimStokMTMRepository.GetAll(o => o.KareKodBildirimEmriId == Id);
            stokMtms = stokMtms.DistinctBy(o => o.KareKodStokId).ToList();
            foreach (var item in stokMtms)
            {
                var flag = true;
                foreach (var alredyexits in alredyExistsStoks)
                {
                    if (alredyexits.KareKodStokId == item.KareKodStokId)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                {
                    continue;
                }
                item.AddedDate = DateTime.Now;
                _kareKodBildirimStokMTMRepository.Add(item);
            }


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }











        public IActionResult ÜretimiBitir(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();

            var IşEmri = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            if (IşEmri.OrderStatus != 0)
            {
                res.status = 0;
                res.message = "İş Emri Kapatılamıyor";
                return Json(res);
            }
            IşEmri.OrderStatus = 1;
            _kareKodIsEmriRepository.Update(IşEmri);
            var UretilenUrunler = _kareKodUrunlerRepository.GetAll(o => o.WorkOrderId == Id);
            foreach (var item in UretilenUrunler)
            {
                item.Id = 0;
                _kareKodStokRepository.Add(ConvertToKareKodStok(item));
            }

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public KareKodStok ConvertToKareKodStok(KareKodUrunler urun)
        {
            if (urun == null)
                throw new ArgumentNullException(nameof(urun));

            return new KareKodStok
            {
                Id = urun.Id, // BaseEntity'den geliyor
                Sn = urun.Sn,
                Bn = urun.Bn,
                Gtin = urun.Gtin,
                Xd = urun.Xd,
                Md = urun.Md,
                QrCode = urun.QrCode,
                PaletSscc = urun.PaletSscc,
                BoxSscc = urun.BoxSscc,
                PackSscc = urun.PackSscc,
                InStock = 1, // Varsayılan olarak 0 veya uygun bir değerle doldurulabilir
                NotificationStatus = 0 // Varsayılan olarak 0 veya uygun bir değerle doldurulabilir
            };
        }


        [HttpGet]
        public IActionResult MüşteriYetkilisiAdd(int Id)
        {
            MüşteriYetkilisiAddViewModel model = new MüşteriYetkilisiAddViewModel();
            model.Id = Id;
            return View(model);
        }

        public IActionResult MüşteriYetkilisiDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _kareKodMüşteriYetkilileriRepository.Get(o => o.Id == Id);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }

            _kareKodMüşteriYetkilileriRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";

            return Json(res);
        }

        [HttpPost]

        public IActionResult MüşteriYetkilisiAdd(int MüşteriId, string AdSoyad, string Email, string Phone)
        {
            JsonResponseModel res = new JsonResponseModel();
            if (MüşteriId == 0)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }
            if (String.IsNullOrEmpty(AdSoyad))
            {
                res.status = 0;
                res.message = "Ad Soyad Alanı Boş Bıraklılamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(Email))
            {
                res.status = 0;
                res.message = "Email Alanı Boş Bıraklılamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(Phone))
            {
                res.status = 0;
                res.message = "Telefon Alanı Boş Bıraklılamaz";
                return Json(res);
            }

            KareKodMüşteriYetkilileri entity = new KareKodMüşteriYetkilileri();
            entity.AdSoyad = AdSoyad;
            entity.Email = Email;
            entity.Phone = Phone;
            entity.KareKodMüşteriId = MüşteriId;
            _kareKodMüşteriYetkilileriRepository.Add(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }



        public IActionResult MüşteriYetkilileri(int Id)
        {
            MüşteriYetkilileriViewModel model = new MüşteriYetkilileriViewModel();
            model.Id = Id;

            return View(model);
        }


        public IActionResult MüşteriYetkilileriPagination(int offset, int limit, string search, int Id)
        {

            MüşteriYetkilileriPaginationModel model = new MüşteriYetkilileriPaginationModel();
            model.rows = _kareKodMüşteriYetkilileriRepository.GetAllIncludedPagination(o => o.KareKodMüşteriId == Id, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodMüşteriYetkilileriRepository.GetAllIncludedPaginationCount(o => o.KareKodMüşteriId == Id, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodMüşteriYetkilileriRepository.GetAllIncludedPaginationCount(o => o.KareKodMüşteriId == Id, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }

        public IActionResult Müşteriler()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MüşteriAdd()
        {

            return View();
        }

        public IActionResult MüşteriDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _kareKodMüşteriRepository.Get(o => o.Id == Id);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }

            _kareKodMüşteriRepository.Delete(entity);

            res.status = 1;
            res.message = "İşlem Başarılı";



            return Json(res);
        }
        [HttpPost]
        public IActionResult MüşteriAdd(string Adı, string Gln, string ToGln, string Adres)
        {
            JsonResponseModel res = new JsonResponseModel();
            KareKodMüşteri entity = new KareKodMüşteri();
            if (String.IsNullOrEmpty(Adı))
            {
                res.status = 0;
                res.message = "Adı Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(Gln))
            {
                res.status = 0;
                res.message = "Şube Gln Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(ToGln))
            {
                res.status = 0;
                res.message = "Merkez Gln Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(Adres))
            {
                res.status = 0;
                res.message = "Adres Alanı Boş Bırakılamaz";
                return Json(res);
            }
            entity.Adı = Adı;
            entity.GLN = Gln;
            entity.ToGLN = ToGln;
            entity.Adres = Adres;
            _kareKodMüşteriRepository.Add(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult MüşterilerPagination(int offset, int limit, string search)
        {

            KareKodMüşterilerPaginationModel model = new KareKodMüşterilerPaginationModel();
            model.rows = _kareKodMüşteriRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodMüşteriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodMüşteriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);

        }

        public IActionResult BildirimEmirleri()
        {


            return View();
        }


        [HttpGet]
        // [Route("/KareKod/EmirEkle")]
        public IActionResult EmirEkleYeni()
        {
            BildirimEkleViewModel model = new BildirimEkleViewModel();
            model.BildirimTürüs = _kareKodBildirimTürüRepository.GetAll();
            model.KareKodAnaUruns = _kareKodAnaUrunRepository.GetAll();
            model.kareKodDeaktivasyonTürüs = _kareKodDeaktivasyonTürüRepository.GetAll();
            model.KareKodMüşteris = _kareKodMüşteriRepository.GetAll();
            return View(model);
        }

        public IActionResult BildirimEmriPagination(int offset, int limit, string search)
        {
            BildirimEmriPaginationModel model = new BildirimEmriPaginationModel();
            model.rows = _kareKodBildirimEmriRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodBildirimEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodBildirimEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }

        [HttpPost]
        public IActionResult BildirimEmriEkle(int BildirimTürü, int AnaUrunId, DateTime DökümanTarihi, int Adet, string FaturaNo, string SiparişNumarası, string Açıklama, string KayıtDışıFirmaBilgisi, string DökümanNo, int DeaktivasyonKodu, int MüşteriId)
        {

            KareKodBildirimEmri entity = new KareKodBildirimEmri();
            entity.AddedDate = DateTime.Now;

            if (BildirimTürü == 1)
            {
                entity.KareKodBildirimTürüId = 1;
                entity.KareKodAnaUrunId = AnaUrunId;
                entity.DökümanNo = DökümanNo;
                entity.Adet = Adet;
                entity.DökümanTarihi = DökümanTarihi;
                entity.Açıklama = Açıklama;
            }
            if (BildirimTürü == 2)
            {
                entity.KareKodBildirimTürüId = 2;
                entity.KareKodAnaUrunId = AnaUrunId;
                entity.DökümanNo = DökümanNo;
                entity.DökümanTarihi = DökümanTarihi;
                entity.Adet = Adet;
                entity.KareKodMüşteriId = MüşteriId;
                entity.Açıklama = Açıklama;
                entity.FaturaNo = FaturaNo;
                entity.SiparişNo = SiparişNumarası;
            }
            if (BildirimTürü == 3)
            {
                entity.KareKodBildirimTürüId = 3;
                entity.KareKodAnaUrunId = AnaUrunId;
                entity.Adet = Adet;
                entity.Açıklama = Açıklama;
            }
            if (BildirimTürü == 6)
            {
                entity.KareKodBildirimTürüId = 6;
                entity.KareKodAnaUrunId = AnaUrunId;
                entity.KareKodDeaktivasyonTürüId = DeaktivasyonKodu;
                entity.DökümanNo = DökümanNo;
                entity.DökümanTarihi = DökümanTarihi;
                entity.Adet = Adet;
                entity.Açıklama = Açıklama;
                //entity.KareKodDeaktivasyonTürüId = _kareKodDeaktivasyonTürüRepository.Get(o => o.DeaktivasyonKodu == DeaktivasyonKodu.ToString()).Id;
            }

            _kareKodBildirimEmriRepository.Add(entity);
            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }



        private string connectionString = "Server=.;User ID=sa;Password=EdisPharma%1;Database=ITS";

        public IActionResult Aktarım()
        {
            return View();
        }



        public IActionResult StokAktar()
        {
            //var StoktakiÜrünler = GetKareKodStok();
            //foreach (var item in StoktakiÜrünler)
            //{
            //    _kareKodStokRepository.Add(item);
            //}
            //var bildirimEmirleris = GetKareKodBildirimEmirleri();
            //foreach (var bildirimEmri in bildirimEmirleris)
            //{
            //    var entityOldId = bildirimEmri.Id;
            //    bildirimEmri.Id = 0;
            //    var addedBildirimEmri = _kareKodBildirimEmriRepository.Add(bildirimEmri);
            //    var stokBildirmStokMtm = GetKareKodBildirimStokMTM(entityOldId);
            //    foreach (var stokBildirimMtm in stokBildirmStokMtm)
            //    {
            //        KareKodBildirimStokMTM kareKodBildirimStokMTM = new KareKodBildirimStokMTM();
            //        kareKodBildirimStokMTM.KareKodBildirimEmriId = addedBildirimEmri.Id;
            //        var StoktakiÜrün = StoktakiÜrünler.Where(o => o.Id == stokBildirimMtm.KareKodStokId).FirstOrDefault();
            //        StoktakiÜrün.Id = 0;
            //        var ekleneStokEntity = _kareKodStokRepository.Add(StoktakiÜrün);
            //        kareKodBildirimStokMTM.KareKodStokId = ekleneStokEntity.Id;
            //        kareKodBildirimStokMTM.BildirimDurumu = 0;
            //        _kareKodBildirimStokMTMRepository.Add(kareKodBildirimStokMTM);

            //    }
            //}


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);

        }
        public List<KareKodStok> GetKareKodStok()
        {
            var stokListesi = new List<KareKodStok>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
            SELECT TOP (1000) [ID], [GTIN], [SN], [BN], [XD], [MD], [QR_CODE], 
                               [PACK_SSCC], [BOX_SSCC], [PALET_SSCC], [IN_STOCK], [NOTIFICATION_ST]
            FROM [ITS].[dbo].[STOCK]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var stok = new KareKodStok
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Gtin = reader["GTIN"].ToString(),
                                Sn = Convert.ToInt64(reader["SN"]),
                                Bn = reader["BN"].ToString(),
                                Xd = Convert.ToDateTime(reader["XD"]),
                                Md = Convert.ToDateTime(reader["MD"]),
                                QrCode = reader["QR_CODE"].ToString(),
                                PackSscc = reader["PACK_SSCC"].ToString(),
                                BoxSscc = reader["BOX_SSCC"].ToString(),
                                PaletSscc = reader["PALET_SSCC"].ToString(),
                                InStock = Convert.ToInt32(reader["IN_STOCK"]),
                                NotificationStatus = Convert.ToInt32(reader["NOTIFICATION_ST"])
                            };

                            stokListesi.Add(stok);
                        }
                    }
                }
            }

            return stokListesi;
        }

        public IActionResult MüşteriAktarımınıBaşlat()
        {
            var müşteris = GetKareKodMüşteriler();
            var müşteriYetkilis = GetKareKodMüşteriYetkilileri();


            foreach (var item in müşteris)
            {
                var müşteriYetikilis = müşteriYetkilis.Where(o => o.KareKodMüşteriId == item.Id);
                item.Id = 0;
                var addedEntitiy = _kareKodMüşteriRepository.Add(item);
                foreach (var müşteriYetkili in müşteriYetikilis)
                {
                    müşteriYetkili.KareKodMüşteriId = addedEntitiy.Id;
                    var eklenecekEntitity = müşteriYetkili;
                    try
                    {
                        _kareKodMüşteriYetkilileriRepository.Add(eklenecekEntitity);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            JsonResponseModel res = new JsonResponseModel();

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public List<KareKodMüşteriYetkilileri> GetKareKodMüşteriYetkilileri()
        {
            var yetkililer = new List<KareKodMüşteriYetkilileri>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
            SELECT TOP (1000) [ID], [CUSTOMER_ID], [NAME_SURNAME], [EMAIL], [MOBILE]
            FROM [ITS].[dbo].[CUSTOMER_PERSON]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var yetkili = new KareKodMüşteriYetkilileri
                            {
                                //Id = Convert.ToInt32(reader["ID"]),
                                KareKodMüşteriId = reader["CUSTOMER_ID"] as int?,
                                AdSoyad = reader["NAME_SURNAME"].ToString(),
                                Email = reader["EMAIL"].ToString(),
                                Phone = reader["MOBILE"].ToString(),
                            };

                            yetkililer.Add(yetkili);
                        }
                    }
                }
            }

            return yetkililer;
        }

        public List<KareKodMüşteri> GetKareKodMüşteriler()
        {
            var customers = new List<KareKodMüşteri>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
                    SELECT TOP (1000) [ID],[NAME], [GLN], [TO_GLN], [ADRESS]
                    FROM [ITS].[dbo].[CUSTOMER]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new KareKodMüşteri
                            {
                                Id = (int)reader["ID"],
                                Adı = reader["NAME"].ToString(),
                                GLN = reader["GLN"].ToString(),
                                ToGLN = reader["TO_GLN"].ToString(),
                                Adres = reader["ADRESS"].ToString(),
                                KareKodMüşteriYetkilileris = new List<KareKodMüşteriYetkilileri>() // Eğer yetkililer ile ilgili veri eklenmesi gerekiyorsa buraya ekleyebilirsiniz.
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public IActionResult AktarımıBaşlat()
        {
            var WorkOrders = GetWorkOrders();
            foreach (var İşEmiri in WorkOrders)
            {
                var Urunler = GetUrunler(İşEmiri.ID);
                if (İşEmiri.BaseProductId == 1)
                {
                    İşEmiri.BaseProductId = 4;
                }
                if (İşEmiri.BaseProductId == 2)
                {
                    İşEmiri.BaseProductId = 3;
                }
                if (İşEmiri.BaseProductId == 3)
                {
                    İşEmiri.BaseProductId = 2;
                }
                var İşEmriAddedEntitiy = _kareKodIsEmriRepository.Add(ConvertToKareKodIsEmri(İşEmiri));
                foreach (var Urun in Urunler)
                {
                    Urun.WorkOrderId = İşEmriAddedEntitiy.Id;
                    _kareKodUrunlerRepository.Add(Urun);
                }


            }

            return Json("");
        }

        public IActionResult BildirimEmriAktar()
        {






            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public List<KareKodBildirimEmri> GetKareKodBildirimEmirleri()
        {
            var bildirimEmirleriListesi = new List<KareKodBildirimEmri>();

            using (SqlConnection connection = new SqlConnection("your_connection_string"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
                                SELECT  [ID], [PRODUCT_ID], [NOTIFICATION_TYPE_ID], [QUANTITY], 
                               [CUSTOMER_ID], [DOCUMENT_DATE], [DOCUMENT_NO], 
                               [SENDER], [RECEIVER], [DEAKTIVATION_CODE], 
                               [RECEIVER_DETAIL], [NATIFICATION_STATUS], 
                               [DESCRIPTION], [IS_SEND_PTS], [InvoiceNo], 
                               [PURCHESE_ORDER_NUMBER]
                            FROM [ITS].[dbo].[NOTIFICATION_ORDER]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bildirimEmri = new KareKodBildirimEmri
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                KareKodAnaUrunId = Convert.ToInt32(reader["PRODUCT_ID"]),
                                KareKodBildirimTürüId = Convert.ToInt32(reader["NOTIFICATION_TYPE_ID"]),
                                Adet = reader["QUANTITY"] as int?,
                                KareKodMüşteriId = reader["CUSTOMER_ID"] as int?,
                                DökümanTarihi = reader["DOCUMENT_DATE"] as DateTime?,
                                DökümanNo = reader["DOCUMENT_NO"].ToString(),
                                Sender = reader["SENDER"].ToString(),
                                Receiver = reader["RECEIVER"].ToString(),
                                KareKodDeaktivasyonTürüId = reader["DEAKTIVATION_CODE"] as int?,
                                ReceiverDetail = reader["RECEIVER_DETAIL"].ToString(),
                                BildirimDurumu = Convert.ToInt32(reader["NATIFICATION_STATUS"]),
                                Açıklama = reader["DESCRIPTION"].ToString(),
                                PtsGönderimDurumu = reader["IS_SEND_PTS"] as int?,
                                FaturaNo = reader["InvoiceNo"].ToString(),
                                SiparişNo = reader["PURCHESE_ORDER_NUMBER"].ToString(),

                                // Diğer özellikler varsayılan olarak null bırakıldı, gerektiğinde doldurabilirsiniz.
                                KareKodBildirimTürü = null,
                                KareKodAnaUrun = null,
                                KareKodMüşteri = null,
                                KareKodDeaktivasyonTürü = null
                            };

                            bildirimEmirleriListesi.Add(bildirimEmri);
                        }
                    }
                }
            }

            return bildirimEmirleriListesi;
        }







        public List<KareKodBildirimStokMTM> GetKareKodBildirimStokMTM(int BildirimId)
        {
            var bildirimStokListesi = new List<KareKodBildirimStokMTM>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"
                SELECT [ID], [NOTIFICATION_ORDER_ID], [STOCK_ID], [IS_NOTIFY]
                FROM [ITS].[dbo].[NOTIFICATION_ORDER_STOCK_HISTORY] where  NOTIFICATION_ORDER_ID =  " + BildirimId, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bildirimStok = new KareKodBildirimStokMTM
                            {
                                KareKodBildirimEmriId = reader["NOTIFICATION_ORDER_ID"] as int?,
                                KareKodStokId = reader["STOCK_ID"] as int?,
                                BildirimDurumu = reader["IS_NOTIFY"] as int?,
                                KareKodBildirimEmri = null, // KareKodBildirimEmri objesi gerekiyorsa burada eşleştirilebilir.
                                KareKodStok = null // KareKodStok objesi gerekiyorsa burada eşleştirilebilir.
                            };

                            bildirimStokListesi.Add(bildirimStok);
                        }
                    }
                }
            }

            return bildirimStokListesi;
        }
        public List<KareKodUrunler> GetUrunler(int ID)
        {
            var urunlerList = new List<KareKodUrunler>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT
                    [SN],
                    [BN],
                    [GTIN],
                    [XD],
                    [MD],
                    [QR_CODE],
                    [WOOR_ID],
                    [PALET_SN],
                    [BOX_SN],
                    [PACK_SN],
                    [PALET_SSCC],
                    [BOX_SSCC],
                    [PACK_SSCC]
                FROM [ITS].[dbo].[PRODUCTS] where WOOR_ID = " + ID;

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var urun = new KareKodUrunler
                        {
                            Sn = reader.GetInt64(reader.GetOrdinal("SN")),
                            Bn = reader.GetString(reader.GetOrdinal("BN")),
                            Gtin = reader.GetString(reader.GetOrdinal("GTIN")),
                            Xd = reader.GetDateTime(reader.GetOrdinal("XD")),
                            Md = reader.GetDateTime(reader.GetOrdinal("MD")),
                            QrCode = reader.GetString(reader.GetOrdinal("QR_CODE")),
                            WoorId = reader.GetInt32(reader.GetOrdinal("WOOR_ID")),
                            PaletSn = reader.GetInt32(reader.GetOrdinal("PALET_SN")),
                            BoxSn = reader.GetInt32(reader.GetOrdinal("BOX_SN")),
                            PackSn = reader.GetInt32(reader.GetOrdinal("PACK_SN")),
                            PaletSscc = reader.GetString(reader.GetOrdinal("PALET_SSCC")),
                            BoxSscc = reader.GetString(reader.GetOrdinal("BOX_SSCC")),
                            PackSscc = reader.IsDBNull(reader.GetOrdinal("PACK_SSCC"))
                                        ? null
                                        : reader.GetString(reader.GetOrdinal("PACK_SSCC")),
                            WorkOrderId = reader.GetInt32(reader.GetOrdinal("WOOR_ID"))
                        };
                        urunlerList.Add(urun);
                    }
                }
            }
            return urunlerList;
        }
        public static KareKodIsEmri ConvertToKareKodIsEmri(_KareKodIsEmri source)
        {
            return new KareKodIsEmri
            {
                BaseProductId = source.BaseProductId,
                BaseProduct = source.BaseProduct,
                CreatedDate = source.CreatedDate,
                ExpirationDate = source.ExpirationDate,
                Lot = source.Lot,
                PlannedProduct = source.PlannedProduct,
                PackCount = source.PackCount,
                BoxCount = source.BoxCount,
                PaletCount = source.PaletCount,
                ProductPerPack = source.ProductPerPack,
                ProductPerBox = source.ProductPerBox,
                BoxPerPalet = source.BoxPerPalet,
                PackPerBox = source.PackPerBox,
                OrderStatus = source.OrderStatus,
                Description = source.Description,
                KareKodIsEmriIstasyonMTMId = source.KareKodIsEmriIstasyonMTMId,
                KareKodIsEmriIstasyonMTM = source.KareKodIsEmriIstasyonMTM
            };
        }

        public List<_KareKodIsEmri> GetWorkOrders()
        {

            var isEmriList = new List<_KareKodIsEmri>();

            string query = @"
            SELECT [WOOR_ID]
                  ,[BASE_PRODUCT_ID]
                  ,[CREATED_DATE]
                  ,[EXPIRATION_DATE]
                  ,[LOT]
                  ,[PLANNED_PRODUCT]
                  ,[PACK_COUNT]
                  ,[BOX_COUNT]
                  ,[PALET_COUNT]
                  ,[PRODUCT_PER_PACK]
                  ,[PRODUCT_PER_BOX]
                  ,[PACK_PER_BOX]
                  ,[BOX_PER_PALET]
                  ,[ORDER_STATUS]
                  ,[DESCRIPTION]
              FROM [ITS].[dbo].[WORK_ORDER]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var item = new _KareKodIsEmri
                    {
                        ID = Convert.ToInt32(reader["WOOR_ID"]),
                        BaseProductId = Convert.ToInt32(reader["BASE_PRODUCT_ID"]),
                        CreatedDate = Convert.ToDateTime(reader["CREATED_DATE"]),
                        ExpirationDate = reader["EXPIRATION_DATE"] as DateTime?,
                        Lot = reader["LOT"] as string,
                        PlannedProduct = Convert.ToInt32(reader["PLANNED_PRODUCT"]),
                        PackCount = reader["PACK_COUNT"] as int?,
                        BoxCount = Convert.ToInt32(reader["BOX_COUNT"]),
                        PaletCount = Convert.ToInt32(reader["PALET_COUNT"]),
                        ProductPerPack = reader["PRODUCT_PER_BOX"] as int?,
                        ProductPerBox = reader["PRODUCT_PER_BOX"] as int?,
                        PackPerBox = reader["PACK_PER_BOX"] as int?,
                        BoxPerPalet = Convert.ToInt32(reader["BOX_PER_PALET"]),
                        OrderStatus = Convert.ToInt32(reader["ORDER_STATUS"]),
                        Description = reader["DESCRIPTION"] as string
                    };

                    isEmriList.Add(item);
                }

                reader.Close();
            }

            return isEmriList;
        }

        public IActionResult Istasyon()
        {
            return View();
        }

        public IActionResult IstasyonPagination(int offset, int limit, string search)
        {

            IstasyonPaginationModel model = new IstasyonPaginationModel();

            model.rows = _kareKodIstasyonRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodIstasyonRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodIstasyonRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);

            return Json(model);

        }

        public IActionResult IstasyonSearc(string Name)
        {
            var entites = _kareKodIstasyonRepository.GetAll(o => o.IstasyonAdı == Name);
            return Json(entites);
        }

        public IActionResult IstasyonAdd()
        {
            return View();
        }






        [HttpPost]
        public IActionResult IstasyonAdd(string IstasyonAdı, string IpAdresi, int Port, string X1JetIpAdresi, string YazıcıIpAdresi)
        {
            JsonResponseModel res = new JsonResponseModel();

            KareKodIstasyon kareKodIstasyon = new KareKodIstasyon();
            kareKodIstasyon.IstasyonAdı = IstasyonAdı;
            kareKodIstasyon.IpAdresi = IpAdresi;
            kareKodIstasyon.Port = Port;
            kareKodIstasyon.X1JetIpAdresi = X1JetIpAdresi;
            kareKodIstasyon.YazıcıIpAdresi = YazıcıIpAdresi;

            _kareKodIstasyonRepository.Add(kareKodIstasyon);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult IstasyonDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();


            KareKodIstasyon kareKodIstasyon = _kareKodIstasyonRepository.Get(o => o.Id == Id);

            _kareKodIstasyonRepository.Delete(kareKodIstasyon);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public IActionResult IstasyonEdit(int Id)
        {
            var entity = _kareKodIstasyonRepository.Get(o => o.Id == Id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult IstasyonEdit(string IstasyonAdı, string IpAdresi, int Port, int Id, string X1JetIpAdresi, string YazıcıIpAdresi)
        {
            JsonResponseModel res = new JsonResponseModel();


            KareKodIstasyon kareKodIstasyon = _kareKodIstasyonRepository.Get(o => o.Id == Id);
            kareKodIstasyon.IstasyonAdı = IstasyonAdı;
            kareKodIstasyon.IpAdresi = IpAdresi;
            kareKodIstasyon.Port = Port;
            kareKodIstasyon.X1JetIpAdresi = X1JetIpAdresi;
            kareKodIstasyon.YazıcıIpAdresi = YazıcıIpAdresi;

            _kareKodIstasyonRepository.Update(kareKodIstasyon);

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        public  IActionResult PostData(string data)
        {
            JsonResponseModel res = new JsonResponseModel();
            data = data.Substring(1);
            var qrCode = data.Split('@')[0];
            var isExists = _kareKodUrunlerRepository.Get(o => o.QrCode == qrCode);

            if (isExists != null)
            {
                KareKodUretimResponseModel messageModel = new KareKodUretimResponseModel();
                messageModel.isMessage = 1;
                messageModel.Message = "Mükerrer Ürün Bulundu";

                string message = JsonConvert.SerializeObject(messageModel);
                _webSocketHandler.BroadcastAsync(message);

                res.status = 0;
                res.message = "Mükerrer Ürün Bulundu";
                return Json(res);
            }
            var işemriId = data.Split('@')[1];
            int _işemriId = Convert.ToInt32(işemriId);



            var parsedString = ParseString(data.Split('@')[0]);
            var IsEmri = _kareKodIsEmriRepository.GetAllIncluded(o => o.Id == _işemriId).OrderByDescending(o => o.Id).FirstOrDefault();
            if (IsEmri == null)
            {
                KareKodUretimResponseModel messageModel = new KareKodUretimResponseModel();
                messageModel.isMessage = 1;
                messageModel.Message = "Hattan Yanlış Ürün Geçirildi";

                string message = JsonConvert.SerializeObject(messageModel);
                _webSocketHandler.BroadcastAsync(message);
                res.status = 0;
                res.message = "Hattan Yanlış Ürün Geçirildi";
                return Json(res);
            }
            var UrunCounter = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == _işemriId);
            if (UrunCounter >= IsEmri.PlannedProduct)
            {
                KareKodUretimResponseModel messageModel = new KareKodUretimResponseModel();
                messageModel.isMessage = 1;
                messageModel.Message = "Daha Fazla Ürüm Bu İş Emrine Eklenemez";

                string message = JsonConvert.SerializeObject(messageModel);
                _webSocketHandler.BroadcastAsync(message);
                res.status = 0;
                res.message = "Daha Fazla Ürüm Bu İş Emrine Eklenemez";
                return Json(res);
            }
            if (parsedString.Item4 != IsEmri.Lot)
            {
                KareKodUretimResponseModel messageModel = new KareKodUretimResponseModel();
                messageModel.isMessage = 1;
                messageModel.Message = "Hattan Farklı Lot Numarası Geçirildi";

                string message = JsonConvert.SerializeObject(messageModel);
                _webSocketHandler.BroadcastAsync(message);
                res.status = 0;
                res.message = "Hattan Farklı Lot Numarası Geçirildi";
                return Json(res);
            }





            KareKodUrunler entity = new KareKodUrunler();
            entity.AddedDate = DateTime.Now;
            entity.Gtin = parsedString.Item1;
            entity.Sn = Convert.ToInt32(parsedString.Item2.TrimStart('0'));

            entity.Xd = Convert.ToDateTime(IsEmri.ExpirationDate);
            entity.Md = IsEmri.CreatedDate;
            entity.Bn = parsedString.Item4;
            entity.QrCode = data.Split("@")[0];
            var koliPaletSn = KoliPaletNumarasıVer(IsEmri);
            entity.WoorId = IsEmri.Id;
            entity.BoxSn = koliPaletSn.Item1;
            entity.BoxSscc = SSCC("1", entity.BoxSn);
            entity.PaletSn = koliPaletSn.Item2;
            entity.PaletSscc = SSCC("0", entity.PaletSn);
            entity.WorkOrderId = IsEmri.Id;

            if (entity.Gtin.TrimStart('0') != IsEmri.BaseProduct.Gtin.TrimStart('0'))
            {
                KareKodUretimResponseModel messageModel = new KareKodUretimResponseModel();
                messageModel.isMessage = 1;
                messageModel.Message = "Hattan Yanlış Ürün Geçirildi";

                string message = JsonConvert.SerializeObject(messageModel);
                _webSocketHandler.BroadcastAsync(message);
                res.status = 0;
                res.message = "Hattan Yanlış Ürün Geçirildi";
                return Json(res);
            }


            _kareKodUrunlerRepository.Add(entity);
            KoliPaletNumarasıVer(IsEmri, true);

            Task.Run(() =>
            {
                KareKodUretimResponseModel model = new KareKodUretimResponseModel();

                model.KareKodUrunler = entity;
                model.KareKodIsEmri = IsEmri;

                var uruneSonVerilenSeriNolar = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == IsEmri.Id);
                var lastKoliSn = uruneSonVerilenSeriNolar == null ? 1 : uruneSonVerilenSeriNolar.BoxSn;
                var lastPlaetSn = uruneSonVerilenSeriNolar == null ? 1 : uruneSonVerilenSeriNolar.PaletSn;
                var IsEmrindekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == IsEmri.Id);
                var kolidekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == IsEmri.Id && o.BoxSn == lastKoliSn);

                var koliİçindekiÜrünSayısı = IsEmri.ProductPerPack;
                var pallettekiKoliSayısı = IsEmri.BoxPerPalet;
                var totalKoliSayısı = Math.Ceiling((decimal)(IsEmrindekiUrunSayısı / koliİçindekiÜrünSayısı));
                model.KoliDolulukOranı = kolidekiUrunSayısı;
                model.PaletDolulukOranı = Convert.ToInt32(totalKoliSayısı);
                model.ToplamUretim = IsEmrindekiUrunSayısı;



                model.BirÖncekiKoliSonSeriNo = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1) != null ? _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1).Sn.ToString() : 1.ToString();
                model.BirÖncekiKoliilkSeriNo = _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1) != null ? _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1).Sn.ToString() : 1.ToString();

                model.DoldurlanKoliSonSeriNo = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn) != null ? _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn).Sn.ToString() : 1.ToString();
                model.DoldurulanKoliilkSeriNo = _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn) != null ? _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn).Sn.ToString() : 1.ToString();

                string message = JsonConvert.SerializeObject(model);

                _webSocketHandler.BroadcastAsync(message);

            });



            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public (int, int) KoliPaletNumarasıVer(KareKodIsEmri kareKodIsEmri, bool yazdırmaKontrol = false)
        {
            var __karekodIsemri = kareKodIsEmri;
            var IsEmrindekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == __karekodIsemri.Id);
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == __karekodIsemri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);

            //var uruneSonVerilenSeriNolar = _kareKodUrunlerRepository.GetLast(o => o.Gtin == kareKodIsEmri.BaseProduct.Gtin);

            var lastKoliSn = 1;
            var lastPlaetSn = 1;
            if (IsEmrindekiUrunSayısı <= 0)
            {

                lastKoliSn = _kareKodKoliRepository.GetMax() == null ? 1 : _kareKodKoliRepository.GetMax().SeriNo;
                lastPlaetSn = _kareKodPaletRepository.GetMax() == null ? 1 : _kareKodPaletRepository.GetMax().SeriNo;

            }
            else
            {

                lastKoliSn = _kareKodKoliRepository.GetMax(o => o.KareKodIsEmriId == __karekodIsemri.Id) == null ? 1 : _kareKodKoliRepository.GetMax(o => o.KareKodIsEmriId == __karekodIsemri.Id).SeriNo;

                lastPlaetSn = _kareKodPaletRepository.GetMax(o => o.KareKodIsEmriId == __karekodIsemri.Id) == null ? 1 : _kareKodPaletRepository.GetMax(o => o.KareKodIsEmriId == __karekodIsemri.Id).SeriNo;

            }


            var koliİçindekiÜrünSayısı = kareKodIsEmri.ProductPerPack;
            var pallettekiKoliSayısı = kareKodIsEmri.BoxPerPalet;
            var kolidekiUrunSayısı = 0;
            kolidekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == __karekodIsemri.Id && o.BoxSn == lastKoliSn);


            if (IsEmrindekiUrunSayısı <= 0)
            {
                if (lastKoliSn != null && lastPlaetSn != null)
                {

                    var _paletVarmı = _kareKodPaletRepository.Get(o => o.SSCC == SSCC("0", lastPlaetSn + 1));
                    if (_paletVarmı == null)
                    {
                        KareKodPalet palet = new KareKodPalet();
                        palet.SSCC = SSCC("0", lastPlaetSn + 1);
                        palet.SeriNo = lastPlaetSn + 1;
                        palet.KareKodIsEmriId = __karekodIsemri.Id;
                        palet.AddedDate = DateTime.Now;
                        _kareKodPaletRepository.Add(palet);
                    }
                    var __kolivarmı = _kareKodKoliRepository.Get(o => o.SSCC == SSCC("1", lastKoliSn + 1));
                    if (__kolivarmı == null)
                    {
                        KareKodKoli koli = new KareKodKoli();
                        koli.PaletSeriNo = lastPlaetSn + 1;
                        koli.SeriNo = lastKoliSn + 1;
                        koli.SSCC = SSCC("1", lastKoliSn + 1);
                        koli.KareKodIsEmriId = __karekodIsemri.Id;
                        koli.AddedDate = DateTime.Now;
                        _kareKodKoliRepository.Add(koli);
                    }
                    return (lastKoliSn + 1, lastPlaetSn + 1);
                }
                var __paletVarmı = _kareKodPaletRepository.Get(o => o.SSCC == SSCC("0", 1));
                if (__paletVarmı == null)
                {
                    KareKodPalet palet = new KareKodPalet();
                    palet.SSCC = SSCC("0", 1);
                    palet.SeriNo = 1;
                    palet.KareKodIsEmriId = __karekodIsemri.Id;
                    palet.AddedDate = DateTime.Now;
                    _kareKodPaletRepository.Add(palet);
                }

                var _kolivarmı = _kareKodKoliRepository.Get(o => o.SSCC == SSCC("1", 1));
                if (_kolivarmı == null)
                {
                    KareKodKoli koli = new KareKodKoli();
                    koli.PaletSeriNo = lastPlaetSn;
                    koli.SeriNo = 1;
                    koli.SSCC = SSCC("1", 1);
                    koli.KareKodIsEmriId = __karekodIsemri.Id;
                    koli.AddedDate = DateTime.Now;
                    _kareKodKoliRepository.Add(koli);
                }
                return (1, 1);
            }
            else
            {
                var totalKoliSayısı = Math.Floor((decimal)(IsEmrindekiUrunSayısı / koliİçindekiÜrünSayısı));
                //var totalPaletSayısı = Math.Ceiling((decimal)(totalKoliSayısı / pallettekiKoliSayısı));
                if (kolidekiUrunSayısı % koliİçindekiÜrünSayısı == 0)
                {
                    if (kolidekiUrunSayısı == 0)
                    {
                        return (lastKoliSn, lastPlaetSn);
                    }
                    else if (totalKoliSayısı % pallettekiKoliSayısı == 0)
                    {
                        if (yazdırmaKontrol == true)
                        {

                            Task.Run(() =>
                            {
                                PaletEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, __karekodIsemri.Id, SSCC("0", lastPlaetSn), lastPlaetSn.ToString());
                            });
                            Task.Run(() =>
                            {
                                KoliEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, SSCC("1", lastKoliSn), __karekodIsemri.Id, koliİçindekiÜrünSayısı);
                            });

                            return (lastKoliSn + 1, lastPlaetSn + 1);
                        }
                        else
                        {
                            var flag3Counter = 0;
                            KareKodPalet _paletVarmı = null;
                            while (true)
                            {
                                _paletVarmı = _kareKodPaletRepository.Get(o => o.SSCC == SSCC("1", lastKoliSn + 1 + flag3Counter));
                                if (_paletVarmı != null)
                                {
                                    flag3Counter++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (_paletVarmı == null)
                            {
                                KareKodPalet palet = new KareKodPalet();
                                palet.SSCC = SSCC("0", lastPlaetSn + 1 + flag3Counter);
                                palet.SeriNo = lastPlaetSn + 1 + flag3Counter;
                                palet.KareKodIsEmriId = __karekodIsemri.Id;
                                palet.AddedDate = DateTime.Now;

                                _kareKodPaletRepository.Add(palet);

                            }
                            var flag2Counter = 0;
                            KareKodKoli _kolivarmı = null;
                            while (true)
                            {
                                _kolivarmı = _kareKodKoliRepository.Get(o => o.KareKodIsEmriId == kareKodIsEmri.Id && o.SSCC == SSCC("1", lastKoliSn + 1 + flag2Counter));
                                if (_kolivarmı != null)
                                {
                                    flag2Counter++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (_kolivarmı == null)
                            {
                                KareKodKoli koli = new KareKodKoli();
                                koli.PaletSeriNo = lastPlaetSn + 1 + flag3Counter;
                                koli.SeriNo = lastKoliSn + 1 + flag2Counter;
                                koli.SSCC = SSCC("1", lastKoliSn + 1 + flag2Counter);
                                koli.KareKodIsEmriId = __karekodIsemri.Id;
                                koli.AddedDate = DateTime.Now;

                                _kareKodKoliRepository.Add(koli);
                            }

                            return (lastKoliSn + 1, lastPlaetSn + 1);
                        }


                    }

                    //var flag1Counter = 0;
                    //KareKodKoli kolivarmı = null;
                    //while (true)
                    //{
                    //    kolivarmı = _kareKodKoliRepository.Get(o => o.SSCC == SSCC("1", lastKoliSn + 1 + flag1Counter));
                    //    if (kolivarmı != null)
                    //    {
                    //        flag1Counter++;
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}

                    //if (kolivarmı == null)
                    //{
                    //    KareKodKoli koli = new KareKodKoli();
                    //    koli.PaletSeriNo = lastPlaetSn;
                    //    koli.SeriNo = lastKoliSn + 1 + flag1Counter;
                    //    koli.SSCC = SSCC("1", lastKoliSn + 1 + flag1Counter);
                    //    koli.KareKodIsEmriId = __karekodIsemri.Id;
                    //    koli.AddedDate = DateTime.Now;

                    //    _kareKodKoliRepository.Add(koli);
                    //    if (yazdırmaKontrol == true)
                    //    {
                    //        Task.Run(() => { KoliEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, SSCC("1", lastKoliSn), __karekodIsemri.Id,   koliİçindekiÜrünSayısı); });
                    //    }

                    //}
                    KareKodKoli kolivarmı = null;
                    kolivarmı = _kareKodKoliRepository.GetLast();
                    KareKodKoli _koli = new KareKodKoli();
                    _koli.PaletSeriNo = lastPlaetSn;
                    _koli.SeriNo = kolivarmı.SeriNo + 1;
                    _koli.SSCC = SSCC("1", kolivarmı.SeriNo + 1);
                    _koli.KareKodIsEmriId = __karekodIsemri.Id;
                    _koli.AddedDate = DateTime.Now;
                    _kareKodKoliRepository.Add(_koli);
                    //if (yazdırmaKontrol == true)
                    //{
                    //    Task.Run(() => { KoliEtitketYazdır(Istasyon.IpAdresi, Istasyon.Port, SSCC("1", lastKoliSn), __karekodIsemri.Id, koliİçindekiÜrünSayısı); });
                    //}
                    return (lastKoliSn + 1, lastPlaetSn);
                }
                else
                {
                    return (lastKoliSn, lastPlaetSn);
                }

            }


        }
        public void PaletEtitketYazdır(string clientİpAdress, int clientPort, int IsEmriId, string paletBarkod, string paletSeriNo, string EskiBarkod = null)
        {
            var işemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriId);
            var urun = _kareKodAnaUrunRepository.Get(o => o.Id == işemri.BaseProductId);
            var Uruns = _kareKodUrunlerRepository.GetAll(o => o.WoorId == IsEmriId && o.PaletSscc == paletBarkod);
            var kolis = _kareKodKoliRepository.GetAllIncludedPaginationCount(o => o.PaletSeriNo == Convert.ToInt64(paletSeriNo));

            PaletEtiket paletEtiket = new PaletEtiket();
            paletEtiket.koliCount = kolis;
            paletEtiket.paletBarkod = paletBarkod;
            paletEtiket.productName = urun.Name + " " + urun.Unit;
            paletEtiket.EskiBarkod = EskiBarkod;

            try
            {
                TcpClient client = new TcpClient(clientİpAdress, clientPort); // Sunucu IP ve port
                NetworkStream stream = client.GetStream();

                // Gönderilecek mesaj
                string message = "PALET_ETIKETIYAZDIR" + clientİpAdress + "@" + JsonConvert.SerializeObject(paletEtiket);
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBuffer, 0, messageBuffer.Length);


                client.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void KoliEtitketYazdır(string clientİpAdress, int clientPort, string KoliEtiketi, int IsEmriId, int? adet, string EskiBarkod = null)
        {
            var işemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriId);
            var urun = _kareKodAnaUrunRepository.Get(o => o.Id == işemri.BaseProductId);

            KoliEtiket koliEtiket = new KoliEtiket();
            koliEtiket.productName = urun.Name + " " + urun.Unit;
            koliEtiket.lotNo = işemri.Lot;
            koliEtiket.koliBarkod = KoliEtiketi;
            koliEtiket.uretimTarihi = işemri.CreatedDate.ToString("MM/yyyy");
            koliEtiket.sonKullanmaTarihi = işemri.ExpirationDate?.ToString("MM/yyyy");
            koliEtiket.adet = adet;
            koliEtiket.EskiBarkod = EskiBarkod;
            try
            {
                TcpClient client = new TcpClient(clientİpAdress, clientPort); // Sunucu IP ve port
                NetworkStream stream = client.GetStream();

                // Gönderilecek mesaj
                string message = "KOLI_ETIKETIYAZDIR" + clientİpAdress + "@" + JsonConvert.SerializeObject(koliEtiket);
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBuffer, 0, messageBuffer.Length);


                client.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static string SSCC(string ayırac, int _seri)
        {
            int checksum = 0;
            // GS1 Şirket Önek Kodu (örnek olarak 8681395450 kullanıldı)
            string prefix = "8681395450";

            // SSCC'yi oluşturmak için ayıracı ve seri numarasını birleştiriyoruz
            string ssccBody = string.Concat(ayırac, prefix, Convert7Digit(_seri));

            // Kontrol basamağını hesaplıyoruz
            for (int i = 16; i >= 0; i--)
            {
                int digit = Convert.ToInt32(ssccBody[i].ToString());
                if (i % 2 == 0)
                {
                    checksum += digit * 3;
                }
                else
                {
                    checksum += digit;
                }
            }

            int controlDigit = (10 - (checksum % 10)) % 10;

            // SSCC'nin son halini oluşturuyoruz
            return string.Concat("00", ssccBody, controlDigit.ToString());
        }

        public static string Convert7Digit(int adet)
        {
            string str;
            try
            {
                switch (adet.ToString().Length)
                {
                    case 1:
                        {
                            str = string.Concat("00000", adet.ToString());
                            return str;
                        }
                    case 2:
                        {
                            str = string.Concat("0000", adet.ToString());
                            return str;
                        }
                    case 3:
                        {
                            str = string.Concat("000", adet.ToString());
                            return str;
                        }
                    case 4:
                        {
                            str = string.Concat("00", adet.ToString());
                            return str;
                        }
                    case 5:
                        {
                            str = string.Concat("0", adet.ToString());
                            return str;
                        }
                    case 6:
                        {
                            str = string.Concat("", adet.ToString());
                            return str;
                        }
                }
                str = adet.ToString();
            }
            catch (Exception exception)
            {
                str = "";
            }
            return str;
        }


        public (string, string, string, string) ParseString(string input)
        {
            // Verilen stringin uzunlukları
            int lengthField1 = 14;
            int lengthField2 = 12;
            int lengthField3 = 6;
            int lengthField4 = 8;

            if (input.Length != (lengthField1 + lengthField2 + lengthField3 + lengthField4 + 8))
            {
                throw new ArgumentException("Girdi uzunluğu beklenen toplam uzunluktan farklı.");
            }

            string field1 = input.Substring(2, lengthField1);
            string field2 = input.Substring(4 + lengthField1, lengthField2);
            string field3 = input.Substring(6 + lengthField1 + lengthField2, lengthField3);
            string field4 = input.Substring(8 + lengthField1 + lengthField2 + lengthField3, lengthField4);

            return (field1, field2, field3, field4);
        }
        public async Task<IActionResult> UretimEkranı(int Id)
        {
            KareKodUretimEkranıViewModel model = new KareKodUretimEkranıViewModel();
            model.KareKodIsEmri = _kareKodIsEmriRepository.Get(o => o.Id
            == Id);
            model.SonKoliSn = _kareKodUrunlerRepository.GetAll(o => o.WoorId == Id).OrderByDescending(o => o.Id).FirstOrDefault() != null ? _kareKodUrunlerRepository.GetAll(o => o.WoorId == Id).OrderByDescending(o => o.Id).FirstOrDefault().BoxSn : 1;
            var IstasyonMtm = _kareKodIsEmriIstasyonMTMRepository.Get(o => o.KareKodIsEmriId == model.KareKodIsEmri.Id).KareKodIstasyonId;
            var Istasyon = _kareKodIstasyonRepository.Get(o => o.Id == IstasyonMtm);
            model.KareKodIstasyon = Istasyon;
            Task.Run(() => { ClienteBilgileriGönder(Istasyon.IpAdresi, Istasyon.Port, Id); });
            Task.Run(() => { KareKodLabelBilgisiGönder(Istasyon.IpAdresi, Istasyon.Port, Id); });

            var uruneSonVerilenSeriNolar = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id);
            var lastKoliSn = uruneSonVerilenSeriNolar == null ? 1 : uruneSonVerilenSeriNolar.BoxSn;
            var lastPlaetSn = uruneSonVerilenSeriNolar == null ? 1 : uruneSonVerilenSeriNolar.PaletSn;
            var IsEmrindekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == model.KareKodIsEmri.Id);
            var kolidekiUrunSayısı = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn);

            var koliİçindekiÜrünSayısı = model.KareKodIsEmri.ProductPerPack;
            var pallettekiKoliSayısı = model.KareKodIsEmri.BoxPerPalet;
            var totalKoliSayısı = Math.Ceiling((decimal)(IsEmrindekiUrunSayısı / koliİçindekiÜrünSayısı));
            model.KoliDolulukOranı = kolidekiUrunSayısı;
            model.PaletDolulukOranı = Convert.ToInt32(totalKoliSayısı);
            model.ToplamUretim = IsEmrindekiUrunSayısı;


            model.BirÖncekiKoliSonSeriNo = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1) != null ? _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1).Sn.ToString() : 1.ToString();
            model.BirÖncekiKoliilkSeriNo = _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1) != null ? _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn - 1).Sn.ToString() : 1.ToString();

            model.DoldurlanKoliSonSeriNo = _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn) != null ? _kareKodUrunlerRepository.GetLast(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn).Sn.ToString() : 1.ToString();
            model.DoldurlanKoliilkSeriNo = _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn) != null ? _kareKodUrunlerRepository.GetFirst(o => o.WorkOrderId == model.KareKodIsEmri.Id && o.BoxSn == lastKoliSn).Sn.ToString() : 1.ToString();





            return View(model);
        }


        public IActionResult KareKodSil(int Id)
        {
            var entity = _kareKodUrunlerRepository.Get(o => o.Id == Id);
            _kareKodUrunlerRepository.Delete(entity);


            JsonResponseModel res = new JsonResponseModel();
            res.status = 1;
            res.message = "İşlem Başaşrılı";
            return Json(res);
        }
        public async Task<IActionResult> KareKodUrunlerPagination(int offset, int limit, List<int> orderStatusId, string search, int Id, int KoliNo)
        {
            KareKodUrunlerPaginationModel model = new KareKodUrunlerPaginationModel();

            model.rows = _kareKodUrunlerRepository.GetAllIncludedPagination(o => o.WoorId == Id && o.BoxSn == KoliNo, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WoorId == Id && o.BoxSn == KoliNo, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodUrunlerRepository.GetAllIncludedPaginationCount(o => o.WoorId == Id && o.BoxSn == KoliNo, offset.ToString(), limit.ToString(), search);

            return Json(model);
        }




        public void ClienteBilgileriGönder(string clientİpAdress, int clientPort, int IsEmriId)
        {
            var işemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriId);
            PrinterPropModel printerPropModel = new PrinterPropModel();
            try
            {
                TcpClient client = new TcpClient(clientİpAdress, clientPort); // Sunucu IP ve port
                NetworkStream stream = client.GetStream();

                // Gönderilecek mesaj
                string message = "YENI_GOREV" + clientİpAdress + "@" + JsonConvert.SerializeObject(işemri);
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBuffer, 0, messageBuffer.Length);



                client.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }
        public void KareKodLabelBilgisiGönder(string clientİpAdress, int clientPort, int IsEmriId)
        {
            var işemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriId);
            var urun = _kareKodAnaUrunRepository.Get(o => o.Id == işemri.BaseProductId);
            var Gtin = urun.Gtin;
            //işemri.BaseProduct.Gtin
            PrinterPropModel printerPropModel = new PrinterPropModel();
            var LastUrun = _kareKodUrunlerRepository.GetMaxSn(o => o.Gtin == Gtin.PadLeft(13, '0'));
            printerPropModel.Lot = işemri.Lot;
            printerPropModel.Serial = LastUrun != null ? (LastUrun.Sn + 1).ToString().PadLeft(10, '0') : 1.ToString().PadLeft(10, '0');
            printerPropModel.LastSerial = "999999999";
            printerPropModel.Expire = işemri.ExpirationDate?.ToString("yyMMdd");
            printerPropModel.GozukenExpire = işemri.ExpirationDate?.ToString("ddMMyy");
            printerPropModel.Gtin = Gtin.PadLeft(13, '0');


            try
            {
                TcpClient client = new TcpClient(clientİpAdress, clientPort); // Sunucu IP ve port
                NetworkStream stream = client.GetStream();

                // Gönderilecek mesaj
                string message = "KAREKOD_LABEL_BILGISI" + clientİpAdress + "@" + JsonConvert.SerializeObject(printerPropModel);
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBuffer, 0, messageBuffer.Length);



                client.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }



        public IActionResult İstasyonListesiPagination(int offset, int limit, List<int> orderStatusId, string search, string İpBlogu)
        {
            var clients = GetClientSettings(İpBlogu);

            İstasyonListesiPaginationModel model = new İstasyonListesiPaginationModel();
            model.rows = clients;
            model.total = clients.Count();
            model.totalNotFiltered = clients.Count();

            return Json(model);
        }
        public List<ClinetSettings> GetClientSettings(string İpBlogu)
        {
            List<ClinetSettings> clientSettings = new List<ClinetSettings>();

            string subnet = İpBlogu; // Ağınızın alt ağını burada belirtin
            int port = 10566; // Dinlemek istediğiniz portu buraya girin

            for (int i = 1; i < 255; i++)
            {
                string ipAddress = subnet + i.ToString();
                if (ScanPort(ipAddress, port, 500))
                {
                    try
                    {
                        TcpClient client = new TcpClient(ipAddress, port); // Sunucu IP ve port
                        NetworkStream stream = client.GetStream();

                        // Gönderilecek mesaj
                        string message = "SUNUCU_BILGILERI"; // Veya "ZAMAN"
                        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                        stream.Write(messageBuffer, 0, messageBuffer.Length);

                        // Cevabı alma
                        byte[] buffer = new byte[1024];
                        int byteCount = stream.Read(buffer, 0, buffer.Length);
                        string responseMessage = Encoding.UTF8.GetString(buffer, 0, byteCount);
                        Console.WriteLine($"Sunucudan gelen mesaj: {responseMessage}");

                        clientSettings.Add(JsonConvert.DeserializeObject<ClinetSettings>(responseMessage));

                        client.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return clientSettings;


        }


        public bool ScanPort(string ipAddress, int port, int timeout)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    IAsyncResult result = client.BeginConnect(ipAddress, port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));

                    if (success && client.Connected)
                    {
                        Console.WriteLine($"Port {port} is open on {ipAddress}");
                        // Mesaj gönderip yanıt almak isterseniz burada yapabilirsiniz
                        client.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> IsEmirleriPagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            KareKodIsEmriPaginationModel model = new KareKodIsEmriPaginationModel();
            model.rows = _kareKodIsEmriRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodIsEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodIsEmriRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }
        public IActionResult IsEmriEkle()
        {
            IsEmriEkleViewModel model = new IsEmriEkleViewModel();
            model.KareKodAnaUruns = _kareKodAnaUrunRepository.GetAll();
            model.KareKodIstasyons = _kareKodIstasyonRepository.GetAll();

            return View(model);
        }
        public IActionResult IsEmriSil(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var enttiy = _kareKodIsEmriRepository.Get(o => o.Id == Id);
            if (enttiy == null)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }
            _kareKodIsEmriRepository.Delete(enttiy);
            var Urunlers = _kareKodUrunlerRepository.GetAll(o => o.WoorId == Id);
            foreach (var item in Urunlers)
            {
                _kareKodUrunlerRepository.Delete(item);
            }
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpPost]
        public IActionResult IsEmriEkle(int BaseProductId, DateTime CreatedDate, DateTime ExpirationDate, string Lot, int PlannedProduct, int ToplamKoliSayısı, int ToplamPaletSayısı, int KolidekiÜrünSayısı, int PalettekiKoliSayısı, string Açıklama, int IstasyonId)
        {
            JsonResponseModel res = new JsonResponseModel();
            if (BaseProductId == 0)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }
            if (CreatedDate == null)
            {
                res.status = 0;
                res.message = "Oluşturma Tarihi Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (ExpirationDate == null)
            {
                res.status = 0;
                res.message = "Son Kullanma Tarihi Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (string.IsNullOrEmpty(Lot))
            {
                res.status = 0;
                res.message = "Lot Boş Bırakılamaz";
                return Json(res);
            }

            if (PlannedProduct <= 0)
            {
                res.status = 0;
                res.message = "Planlanan Ürün Alanı Boş Bırakılamaz";
                return Json(res);
            }

            if (ToplamKoliSayısı <= 0)
            {
                res.status = 0;
                res.message = "Toplam Koli Sayısı Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (ToplamPaletSayısı <= 0)
            {
                res.status = 0;
                res.message = "Toplam Palet Sayısı Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (KolidekiÜrünSayısı <= 0)
            {
                res.status = 0;
                res.message = "Kolideki Ürün Sayısı Alanı Boş Bırakılamaz";
                return Json(res);
            }
            if (PalettekiKoliSayısı <= 0)
            {
                res.status = 0;
                res.message = "Paletteki Koli Sayısı Alanı Boş Bırakılamaz";
                return Json(res);
            }

            KareKodIsEmri entitiy = new KareKodIsEmri();
            entitiy.BaseProductId = BaseProductId;
            entitiy.CreatedDate = CreatedDate;
            entitiy.ExpirationDate = ExpirationDate;
            entitiy.Lot = Lot;
            entitiy.PlannedProduct = PlannedProduct;
            entitiy.BoxCount = ToplamKoliSayısı;
            entitiy.PaletCount = ToplamPaletSayısı;
            entitiy.ProductPerPack = KolidekiÜrünSayısı;
            entitiy.BoxPerPalet = PalettekiKoliSayısı;
            entitiy.Description = Açıklama;




            var addedEntity = _kareKodIsEmriRepository.Add(entitiy);

            KareKodIsEmriIstasyonMTM entity = new KareKodIsEmriIstasyonMTM();
            entity.KareKodIsEmriId = addedEntity.Id;
            entity.KareKodIstasyonId = IstasyonId;
            var addedSecond = _kareKodIsEmriIstasyonMTMRepository.Add(entity);
            //addedEntity.KareKodIsEmriIstasyonMTMId = addedSecond.Id;

            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }

        public IActionResult GetKareKodAnaUrunProps(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entitiy = _kareKodAnaUrunRepository.Get(o => o.Id == Id);
            if (entitiy == null)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }
            res.status = 1;
            res.data = entitiy;
            return Json(res);
        }



        public IActionResult SonKullanmaTarihiHesapla(int Id, DateTime UretimTar, int RafCycleTime)
        {
            JsonResponseModel model = new JsonResponseModel();

            var anaUrun = _kareKodAnaUrunRepository.Get(o => o.Id == Id);
            var TarihString = "";
            if (Id == 0)
            {
                model.status = 0;
                model.message = "Aranan İçerik Bulunamadı";
                return Json(model);
            }

            if (anaUrun.RafCycleUnit == 1.ToString())
            {
                UretimTar = UretimTar.AddYears(RafCycleTime);
            }
            if (anaUrun.RafCycleUnit == 2.ToString())
            {
                UretimTar = UretimTar.AddMonths(RafCycleTime);
            }
            if (anaUrun.RafCycleUnit == 3.ToString())
            {
                UretimTar = UretimTar.AddDays(RafCycleTime);
            }

            TarihString = UretimTar.ToString("yyyy-MM-dd");
            model.status = 1;
            model.data = TarihString;
            return Json(model);
        }









        public async Task<IActionResult> AnaUrunler()
        {
            return View();
        }
        public async Task<IActionResult> AnaUrunlerPagination(int offset, int limit, List<int> orderStatusId, string search)
        {
            AnaUrunlerPaginatonModel model = new AnaUrunlerPaginatonModel();
            model.rows = _kareKodAnaUrunRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _kareKodAnaUrunRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            model.totalNotFiltered = _kareKodAnaUrunRepository.GetAllIncludedPaginationCount(null, offset.ToString(), limit.ToString(), search);
            return Json(model);
        }
        public IActionResult AnaUrunDelete(int Id)
        {
            JsonResponseModel res = new JsonResponseModel();
            var entity = _kareKodAnaUrunRepository.Get(o => o.Id == Id);
            if (entity == null)
            {
                res.status = 0;
                res.message = "Aranan Veri Bulunamadı";
                return Json(res);
            }
            _kareKodAnaUrunRepository.Delete(entity);
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpGet]
        public IActionResult AnaUrunAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnaUrunAdd(KareKodAnaUrun _entitiy)
        {
            JsonResponseModel res = new JsonResponseModel();
            if (String.IsNullOrEmpty(_entitiy.Name))
            {
                res.status = 0;
                res.message = "Ana Ürün İsim Alanı Boş Olamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(_entitiy.Gtin))
            {
                res.status = 0;
                res.message = "Ana Ürün Gtin Alanı Boş Olamaz";
                return Json(res);
            }

            if (String.IsNullOrEmpty(_entitiy.Unit))
            {
                res.status = 0;
                res.message = "Ana Ürün Birim Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.RafCycleTime == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Raf Ömrü Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.RafCycleUnit == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Raf Ömrü Birimi Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.BoxesInPalet == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Paletteki Kutu Adeti Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.ProductInBox == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Kutudatki Ürün Adeti Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.ProductsInPack == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Kutudaki Ürün Adeti Alanı Boş Olamaz";
                return Json(res);
            }
            _kareKodAnaUrunRepository.Add(_entitiy);



            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }


        [HttpGet]
        public IActionResult AnaUrunEdit(int Id)
        {
            var entitiy = _kareKodAnaUrunRepository.Get(o => o.Id
            == Id);
            return View(entitiy);
        }
        [HttpPost]
        public IActionResult AnaUrunEdit(int Id, KareKodAnaUrun _entitiy)
        {
            var entity = _kareKodAnaUrunRepository.Get(o => o.Id == Id);

            JsonResponseModel res = new JsonResponseModel();
            if (entity == null)
            {
                res.status = 0;
                res.message = "Aranan İçerik Bulunamadı";
                return Json(res);
            }

            if (String.IsNullOrEmpty(_entitiy.Name))
            {
                res.status = 0;
                res.message = "Ana Ürün İsim Alanı Boş Olamaz";
                return Json(res);
            }
            if (String.IsNullOrEmpty(_entitiy.Gtin))
            {
                res.status = 0;
                res.message = "Ana Ürün Gtin Alanı Boş Olamaz";
                return Json(res);
            }

            if (String.IsNullOrEmpty(_entitiy.Unit))
            {
                res.status = 0;
                res.message = "Ana Ürün Birim Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.RafCycleTime == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Raf Ömrü Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.RafCycleUnit == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Raf Ömrü Birimi Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.BoxesInPalet == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Paletteki Kutu Adeti Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.ProductInBox == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Kutudatki Ürün Adeti Alanı Boş Olamaz";
                return Json(res);
            }

            if (_entitiy.ProductsInPack == null)
            {
                res.status = 0;
                res.message = "Ana Ürün Kutudaki Ürün Adeti Alanı Boş Olamaz";
                return Json(res);
            }

            // Gelen _entitiy nesnesinin özelliklerini entity'ye aktar
            entity.Name = _entitiy.Name;
            entity.Gtin = _entitiy.Gtin;
            entity.Unit = _entitiy.Unit;
            entity.Origin = _entitiy.Origin;
            entity.RafCycleUnit = _entitiy.RafCycleUnit;
            entity.RafCycleTime = _entitiy.RafCycleTime;
            entity.ProductType = _entitiy.ProductType;
            entity.BoxesInPalet = _entitiy.BoxesInPalet;
            entity.ProductInBox = _entitiy.ProductInBox;
            entity.ProductsInPack = _entitiy.ProductsInPack;
            entity.PacksInBox = _entitiy.PacksInBox;

            _kareKodAnaUrunRepository.Update(entity);



            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }





    }
}
