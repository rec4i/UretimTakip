using Entities.Concrete.OtherEntities;

namespace WebIU.Models.CariViewModels
{
    public class FaturaPrintViewModel
    {
        public Cari Cari { get; set; }
        public List<FaturaDetay> FaturaDetay { get; set; }
        public FaturaBaslık FaturaBaslık { get; set; }
    }
}
