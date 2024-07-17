using Entities.Concrete.OtherEntities;

namespace WebIU.Models.UrunViewModels
{
    public class UrunIndexViewModel
    {
        public Urun Urun { get; set; }
        public List<UrunAşamaları> UrunAşamalarıs { get; set; }

        public List<Tezgah> Tezgahs { get; set; }
    }
}
