using Entities.Concrete.OtherEntities;

namespace WebIU.Models.IşEmriViewModels
{
    public class UrunPagination
    {
        public List<Urun> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
