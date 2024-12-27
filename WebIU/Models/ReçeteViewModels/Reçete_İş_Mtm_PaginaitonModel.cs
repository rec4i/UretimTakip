using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ReçeteViewModels
{
    public class Reçete_İş_Mtm_PaginaitonModel
    {
        public List<Reçete_Iş_MTM> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
