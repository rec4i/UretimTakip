using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaPaginationViewModel
    {
        public List<Dosya> rows { get; set; }
        public List<buttons> buttons { get; set; }

        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
