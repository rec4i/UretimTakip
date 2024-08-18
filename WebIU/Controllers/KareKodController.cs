using Business.Abstract.Services;
using Business.Concrate.Services.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Math;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Globalization;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using WebIU.Models.HelperModels;
using WebIU.Models.KareKodViewModels;
using WebIU.Models.ReçeteViewModels;
using static Entities.Concrete.Contants.Permission;

namespace WebIU.Controllers
{
    public class KareKodController : Controller
    {
        private readonly DataProcessorService _dataProcessor;
        private readonly IWebSocketService _webSocketHandler;
        private readonly IKareKodUrunlerRepository _kareKodUrunlerRepository;
        private readonly IKareKodAnaUrunRepository _kareKodAnaUrunRepository;
        private readonly IKareKodIsEmriRepository _kareKodIsEmriRepository;
        public KareKodController(DataProcessorService dataProcessor, IWebSocketService webSocketHandler, IKareKodUrunlerRepository kareKodUrunlerRepository, IKareKodAnaUrunRepository
            kareKodAnaUrunRepository, IKareKodIsEmriRepository kareKodIsEmriRepository)
        {
            _kareKodAnaUrunRepository = kareKodAnaUrunRepository;
            _webSocketHandler = webSocketHandler;
            _dataProcessor = dataProcessor;
            _kareKodUrunlerRepository = kareKodUrunlerRepository;
            _kareKodIsEmriRepository = kareKodIsEmriRepository;
        }
        public IActionResult İstasyonListesi()
        {
            return View();
        }



        public async Task<IActionResult> PostData(string data)
        {
            string message = JsonConvert.SerializeObject(data);
            await _webSocketHandler.BroadcastAsync(message);
            var parsedString = ParseString(message);
            var IsEmri = _kareKodIsEmriRepository.Get(o => o.Lot == parsedString.Item4);



            KareKodUrunler entity = new KareKodUrunler();
            entity.Gtin = parsedString.Item1;
            entity.Sn = Convert.ToInt32(parsedString.Item2.TrimStart('0'));

            entity.Xd = DateTime.ParseExact(parsedString.Item3, "yyMMdd", CultureInfo.InvariantCulture);
            entity.Md = IsEmri.CreatedDate;
            entity.Bn = parsedString.Item4;
            entity.QrCode = message;
            var koliPaletSn = KoliPaletNumarasıVer(IsEmri);
            entity.WoorId = IsEmri.Id;
            entity.BoxSn = koliPaletSn.Item1;
            entity.BoxSscc = SSCC("1", entity.BoxSn);
            entity.PaletSn = koliPaletSn.Item2;
            entity.PaletSscc = SSCC("2", entity.PaletSn);





            return Ok();
        }

        public (int, int) KoliPaletNumarasıVer(KareKodIsEmri kareKodIsEmri)
        {

            var Urunler = _kareKodUrunlerRepository.GetAll(o => o.WoorId == kareKodIsEmri.Id);
            var toplamÜrünSayısı = Urunler.Count();
            if (toplamÜrünSayısı <= 0)
            {
                return (1, 1);
            }

            var lastKoliSn = Urunler.OrderByDescending(o => o.Sn).FirstOrDefault().BoxSn;
            var lastPlaetSn = Urunler.OrderByDescending(o => o.Sn).FirstOrDefault().PaletSn;


            bool paletSnDeğişti = false;
            bool koliSnDeğişti = false;

            var koliİçindekiÜrünSayısı = kareKodIsEmri.ProductPerBox;
            var pallettekiKoliSayısı = kareKodIsEmri.BoxPerPalet;


            if (toplamÜrünSayısı % koliİçindekiÜrünSayısı == 0 && toplamÜrünSayısı > 0)
            {
                KoliEtitketYazdır();
                koliSnDeğişti = true;
            }
            var totalKoliSayısı = Math.Floor((decimal)(toplamÜrünSayısı / koliİçindekiÜrünSayısı));
            var totalPaletSayısı = Math.Floor((decimal)(totalKoliSayısı / pallettekiKoliSayısı));

            if (totalKoliSayısı % pallettekiKoliSayısı == 0 && (toplamÜrünSayısı % koliİçindekiÜrünSayısı == 0 && toplamÜrünSayısı > 0))
            {
                PaletEtitketYazdır();
                paletSnDeğişti = true;

            }




            if (totalKoliSayısı <= 0)
            {
                return (1, 1);
            }
            else
            {
                if (koliSnDeğişti)
                {
                    return ((lastKoliSn + 1), (lastPlaetSn));
                }
                else if (koliSnDeğişti && paletSnDeğişti)
                {
                    return ((lastKoliSn + 1), (lastPlaetSn + 1));
                }
                else
                {
                    return ((lastKoliSn), (lastPlaetSn));
                }


            }


        }
        public void PaletEtitketYazdır()
        {
            // TODO: PaletEtkiketi Yazdır kısımı Yapıalck ClientTen Yazıdacaksın alyyapısını ona göre hazırla
        }
        public void KoliEtitketYazdır()
        {
            // TODO: KoliEtiketi Yazdır kısımı Yapıalck
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
                            str = string.Concat("000000", adet.ToString());
                            return str;
                        }
                    case 2:
                        {
                            str = string.Concat("00000", adet.ToString());
                            return str;
                        }
                    case 3:
                        {
                            str = string.Concat("0000", adet.ToString());
                            return str;
                        }
                    case 4:
                        {
                            str = string.Concat("000", adet.ToString());
                            return str;
                        }
                    case 5:
                        {
                            str = string.Concat("00", adet.ToString());
                            return str;
                        }
                    case 6:
                        {
                            str = string.Concat("0", adet.ToString());
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
            if (input.Length != 42)
                throw new ArgumentException("Giriş verisi doğru uzunlukta değil.");

            string part1 = input.Substring(2, 13);  // "08681812046213"
            string part2 = input.Substring(17, 12); // "000005680395"
            string part3 = input.Substring(31, 6);  // "260813"
            string part4 = input.Substring(37, 8);  // "24080231"

            return (part1, part2, part3, part4);
        }
        public async Task<IActionResult> UretimEkranı()
        {
            Task.Run(() => { ClienteBilgileriGönder("192.168.1.34", 10566, 2); });
            Task.Run(() => { KareKodLabelBilgisiGönder("192.168.1.34", 10566, 2); });

            return View();
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
                string message = "YENI_GOREV@" + JsonConvert.SerializeObject(işemri);
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
            var LastUrun = _kareKodUrunlerRepository.GetLast(o => o.Gtin == Gtin.PadLeft(13, '0'));
            printerPropModel.Lot = işemri.Lot;
            printerPropModel.LastSerial = LastUrun != null ? (LastUrun.Sn + 1).ToString().PadLeft(10, '0') : 1.ToString().PadLeft(10, '0');
            printerPropModel.Expire = işemri.ExpirationDate?.ToString("ddMMyy");
            printerPropModel.Gtin = Gtin.PadLeft(13, '0');


            try
            {
                TcpClient client = new TcpClient(clientİpAdress, clientPort); // Sunucu IP ve port
                NetworkStream stream = client.GetStream();

                // Gönderilecek mesaj
                string message = "KAREKOD_LABEL_BILGISI@" + JsonConvert.SerializeObject(printerPropModel);
                byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBuffer, 0, messageBuffer.Length);



                client.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        //public IActionResult OkumayaBaşla(string ipAddress, int IsEmriId)
        //{
        //    var işemri = _kareKodIsEmriRepository.Get(o => o.Id == IsEmriId);

        //    JsonResponseModel res = new JsonResponseModel();
        //    try
        //    {
        //        TcpClient client = new TcpClient(ipAddress, 10566); // Sunucu IP ve port
        //        NetworkStream stream = client.GetStream();

        //        // Gönderilecek mesaj
        //        string message = "OKUMAYA_BASLA@" + JsonConvert.SerializeObject(işemri);
        //        byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
        //        stream.Write(messageBuffer, 0, messageBuffer.Length);



        //        //// Cevabı alma
        //        //byte[] buffer = new byte[1024];
        //        //int byteCount = stream.Read(buffer, 0, buffer.Length);
        //        //string responseMessage = Encoding.UTF8.GetString(buffer, 0, byteCount);
        //        //Console.WriteLine($"Sunucudan gelen mesaj: {responseMessage}");

        //        client.Close();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }




        //    res.status = 1;
        //    res.message = "İşlem Başarılı";
        //    return Json(res);
        //}


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
            res.status = 1;
            res.message = "İşlem Başarılı";
            return Json(res);
        }
        [HttpPost]
        public IActionResult IsEmriEkle(int BaseProductId, DateTime CreatedDate, DateTime ExpirationDate, string Lot, int PlannedProduct, int ToplamKoliSayısı, int ToplamPaletSayısı, int KolidekiÜrünSayısı, int PalettekiKoliSayısı, string Açıklama)
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



            _kareKodIsEmriRepository.Add(entitiy);




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
