using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class StokIndexViewModel
    {
        public List<Birim> Birims { get; set; }
        public List<Depo> Depos { get; set; }

        public string StokKoduTanım { get; set; }

        public int ÜstStokId { get; set; }
        public string StokKoduHazır { get; set; }
    }
}
