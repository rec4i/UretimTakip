using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class BildirimİçeriğiPaginationModel
    {
        public List<KareKodStok> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
