using Entities.Concrete.OtherEntities;
using WebIU.Controllers;

namespace WebIU.Models.SeriNoViewModels
{
    public class FaturaSeriNoPaginationViewModel
    {
        public List<FaturaSeri> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
