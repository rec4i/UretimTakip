using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaİsimDeğiştirmeYetkiPaginationViewModel
    {

        public List<DosyaİsimDeğiştirmeYetki> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
