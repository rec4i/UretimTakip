using Entities.Concrete.OtherEntities;

namespace WebIU.Models.KareKodViewModels
{
    public class AnaUrunlerPaginatonModel
    {
        public List<KareKodAnaUrun> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
