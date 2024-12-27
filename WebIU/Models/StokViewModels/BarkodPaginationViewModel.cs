using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class BarkodPaginationViewModel
    {
        public List<Barkod> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
