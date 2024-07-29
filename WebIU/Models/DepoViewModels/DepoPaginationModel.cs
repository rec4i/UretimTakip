using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DepoViewModels
{
    public class DepoPaginationModel
    {
        public List<Depo> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
