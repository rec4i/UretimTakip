using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class buttons
    {
        public int DosyaId { get; set; }
        public string Button { get; set; }
    }

    public class DosyaİçerikGörmeYetkiPaginationViewModel
    {
        public List<DosyaİçerikGörmeYetki> rows { get; set; }
        public List<buttons> buttons { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
