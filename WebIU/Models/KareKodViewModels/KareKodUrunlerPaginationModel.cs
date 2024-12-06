using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class KareKodUrunlerPaginationModel
    {
        public List<KareKodUrunler> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
