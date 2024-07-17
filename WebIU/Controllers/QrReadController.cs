using Microsoft.AspNetCore.Mvc;

namespace WebIU.Controllers
{
    public class QrReadController : Controller
    {
        public IActionResult QrReader(string qr)
        {
            int requestTipi = Convert.ToInt32(qr.Split("-")[0]);
            string qrCode = qr.Split("-")[1] + "-" + qr.Split("-")[2] + "-" + qr.Split("-")[3] + "-" + qr.Split("-")[4] + "-" + qr.Split("-")[5];

            if (requestTipi == 1)
            {
                return RedirectToAction("Index", "Urun", new { qr = qrCode });
            }

            if (requestTipi == 2)
            {
                return RedirectToAction("TezgahtaYapılacakİşEmirleri", "Tezgah", new { qr = qrCode });

            }



            return Json("");
        }
    }
}
