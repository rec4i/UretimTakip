using System.Net.Sockets;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using WebIU.Models.DepoViewModels;
using WebIU.Models.DökümanModels;
using WebIU.Models.HelperModels;

namespace WebIU.Controllers
{
    public class DökümanController : Controller
    {

        private readonly IDökümanRepository _dökümanRepository;
        public DökümanController(IDökümanRepository dökümanRepository)
        {
            _dökümanRepository = dökümanRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tara()
        {
            JsonResponseModel res = new JsonResponseModel();

            string serverIp = "127.0.0.1"; // Sunucu IP'si
            int serverPort = 10000; // Dinleyicinin portu

            try
            {
                // TCP istemcisini oluştur ve sunucuya bağlan
                using (TcpClient client = new TcpClient(serverIp, serverPort))
                {
                    Console.WriteLine("Sunucuya bağlandı.");

                    // Ağ akışını al
                    NetworkStream stream = client.GetStream();

                    // Gönderilecek mesaj
                    string messageToSend = "Merhaba Sunucu!";
                    byte[] data = Encoding.UTF8.GetBytes(messageToSend);

                    // Mesajı sunucuya gönder
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Gönderilen mesaj: " + messageToSend);

                    // Sunucudan yanıt almak için buffer
                    byte[] responseBuffer = new byte[1024];
                    int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);

                    // Yanıtı ekrana yazdır
                    string responseMessage = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
            
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            Console.WriteLine("Bağlantı kapatıldı.");
            Console.ReadLine(); // Konsolun kapanmasını engelle




            res.status = 1;
            res.message = "İşlem başarılı";

            return Json(res);

        }


        public IActionResult DökümanPaginaton(int offset, int limit, List<int> orderStatusId, string search)
        {

            DökümanPaginationViewModel model = new DökümanPaginationViewModel();
            model.rows = _dökümanRepository.GetAllIncludedPagination(null, offset.ToString(), limit.ToString(), search);
            model.total = _dökümanRepository.GetAllIncludedPaginationCount();
            model.totalNotFiltered = _dökümanRepository.GetAllIncludedPaginationCount();

            return Json(model);


        }



    }
}
