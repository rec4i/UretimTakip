using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class CariSatışViewModel
    {
        public Cari Cari { get; set; }
        public string StokKoduTanım { get; set; }
        public string DepoKoduTanım { get; set; }
        public int FaturaTürü { get; set; }

        public List<FaturaSeri> FaturaSeris { get; set; }
    }
}
