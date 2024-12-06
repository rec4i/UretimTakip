using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class BildirimEmriPaginationModel
    {
        public List<KareKodBildirimEmri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
