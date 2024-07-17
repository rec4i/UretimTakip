using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ReçeteViewModels
{
    public class ReçetePaginatonModel
    {
        public List<Reçete> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
