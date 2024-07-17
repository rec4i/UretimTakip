using Entities.Concrete.OtherEntities;

namespace WebIU.Models.IşEmriViewModels
{
    public class IşEmriPagination
    {
        public List<İşEmri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
