using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DökümanModels
{
    public class DökümanPaginationViewModel
    {
        public List<Döküman> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
