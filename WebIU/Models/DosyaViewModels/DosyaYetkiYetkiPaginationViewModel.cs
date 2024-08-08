using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaYetkiYetkiPaginationViewModel
    {
        public List<DosyaYetkiYetki> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
