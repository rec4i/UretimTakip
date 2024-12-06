using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class BildirimEkleViewModel
    {
        public List<KareKodBildirimTürü> BildirimTürüs { get; set; }
        public List<KareKodAnaUrun> KareKodAnaUruns { get; set; }
        public List<KareKodDeaktivasyonTürü> kareKodDeaktivasyonTürüs { get; set; }
        public List<KareKodMüşteri> KareKodMüşteris { get; set; }
    }
}
