using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class MüşteriYetkilileriPaginationModel
    {
        public List<KareKodMüşteriYetkilileri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
