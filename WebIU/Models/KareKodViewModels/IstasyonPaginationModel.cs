using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class IstasyonPaginationModel
    {
        public List<KareKodIstasyon> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
