using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class StokPaginatonModel
    {
        public List<Stok> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
