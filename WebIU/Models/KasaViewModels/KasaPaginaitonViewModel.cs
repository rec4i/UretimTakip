using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KasaViewModels
{
    public class KasaPaginaitonViewModel
    {
        public List<Kasa> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
