using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class MüşterilerPaginationViewModel
    {
        public List<Cari> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
