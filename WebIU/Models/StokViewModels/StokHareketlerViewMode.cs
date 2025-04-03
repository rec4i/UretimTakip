using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class StokHareketlerViewMode
    {
        public Stok Stok { get; set; }
        public List<StokHareket> StokHarekets { get; set; }
    }
}
