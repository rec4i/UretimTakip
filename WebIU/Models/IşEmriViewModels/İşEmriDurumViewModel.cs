using Entities.Concrete.OtherEntities;

namespace WebIU.Models.IşEmriViewModels
{
    public class İşEmriDurumViewModel
    {
        public List<İşEmriDurum> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
