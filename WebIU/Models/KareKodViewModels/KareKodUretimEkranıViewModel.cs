using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class KareKodUretimEkranıViewModel
    {
        public KareKodIsEmri KareKodIsEmri { get; set; }
        public KareKodIstasyon KareKodIstasyon { get; set; }
        public int SonKoliSn { get; set; }
        public int KoliDolulukOranı { get; set; }
        public int PaletDolulukOranı { get; set; }
        public int ToplamUretim { get; set; }


        public string BirÖncekiKoliSonSeriNo { get; set; }
        public string BirÖncekiKoliilkSeriNo { get; set; }


        public string DoldurlanKoliSonSeriNo { get; set; }
        public string DoldurlanKoliilkSeriNo { get; set; }
    }
}
