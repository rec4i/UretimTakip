using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class KareKodMüşterilerPaginationModel
    {
        public List<KareKodMüşteri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
