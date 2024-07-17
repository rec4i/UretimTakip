
using Entities.Concrete.OtherEntities;

namespace WebIU.Models.TezgahViewModels
{
    public class TezgahPaginationModel
    {
        public List<Tezgah> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
