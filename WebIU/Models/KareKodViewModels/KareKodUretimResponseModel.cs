using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class KareKodUretimResponseModel
    {
        public KareKodUrunler KareKodUrunler { get; set; }
        public KareKodIsEmri KareKodIsEmri { get; set; }

        public int isMessage { get; set; }
        public string Message { get; set; }
        public int KoliDolulukOranı { get; set; }
        public int PaletDolulukOranı { get; set; }
        public int ToplamUretim { get; set; }



        public string BirÖncekiKoliSonSeriNo { get; set; }
        public string BirÖncekiKoliilkSeriNo { get; set; }


        public string DoldurlanKoliSonSeriNo { get; set; }
        public string DoldurulanKoliilkSeriNo { get; set; }
    }
}
