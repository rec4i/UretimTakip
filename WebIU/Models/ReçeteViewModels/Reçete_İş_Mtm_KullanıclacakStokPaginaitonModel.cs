using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ReçeteViewModels
{
    public class Reçete_İş_Mtm_KullanıclacakStokPaginaitonModel
    {
        public List<Reçete_Iş_MTM_KullanılacakStok> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
