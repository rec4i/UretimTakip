using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class PrinterPropModel
    {
        public string Gtin { get; set; }
        public string Expire { get; set; }
        public string Lot { get; set; }
        public string Serial { get; set; }
        public string LastSerial { get; set; }
    }

    public class ClinetSettings
    {
        public string ClientIp { get; set; }
        public string YazıcıIp { get; set; }
        public string KameraIp { get; set; }
        public string X1JetIp { get; set; }
    }
    public class İstasyonListesiPaginationModel
    {
        public List<ClinetSettings> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
