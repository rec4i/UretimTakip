using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ŞantiyeViewModel
{
    public class ŞantiyePaginationViewModel
    {
        public List<Şantiye> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
