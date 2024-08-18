using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class KareKodIsEmriPaginationModel
    {
        public List<KareKodIsEmri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
