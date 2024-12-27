using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class ÖdemePaginaitonViewModel
    {
        public List<Ödeme> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
