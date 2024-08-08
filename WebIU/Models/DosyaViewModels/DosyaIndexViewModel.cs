using Entities.Concrete.OtherEntities;

namespace WebIU.Models.DosyaViewModels
{
    public class DosyaIndexViewModel
    {
        public int ParentId { get; set; }
        public string UserId { get; set; }
        public List<DosyaİsimDeğiştirmeYetki> DosyaİsimDeğiştirmeYetkis { get; set; }
        public List<DosyaSilmeYetki> DosyaSilmeYetkis { get; set; }
        public List<DosyaİndirmeYetki> DosyaİndirmeYetkis { get; set; }
        public List<DosyaİçerikGörmeYetki> DosyaİçerikGörmeYetkis { get; set; }
        public List<DosyaYetkiYetki> DosyaYetkiYetkis { get; set; }
    }
}
