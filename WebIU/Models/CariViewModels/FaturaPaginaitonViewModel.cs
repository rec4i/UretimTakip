using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class FaturaPaginaitonViewModel
    {
        public List<FaturaBaslık> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}

