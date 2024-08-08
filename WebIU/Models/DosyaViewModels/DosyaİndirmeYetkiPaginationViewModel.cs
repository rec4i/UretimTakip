using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaİndirmeYetkiPaginationViewModel
    {
        public List<DosyaİndirmeYetki> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
