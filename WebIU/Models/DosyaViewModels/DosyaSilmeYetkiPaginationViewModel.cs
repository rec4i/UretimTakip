using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaSilmeYetkiPaginationViewModel
    {
        public List<DosyaSilmeYetki> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
