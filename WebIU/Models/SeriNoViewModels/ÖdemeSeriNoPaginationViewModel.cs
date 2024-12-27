using Entities.Concrete.OtherEntities;

namespace WebIU.Models.SeriNoViewModels
{
    public class ÖdemeSeriNoPaginationViewModel
    {
        public List<ÖdemeSeri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
