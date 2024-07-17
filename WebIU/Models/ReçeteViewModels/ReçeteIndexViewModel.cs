using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ReçeteViewModels
{
    public class ReçeteIndexViewModel
    {
        public List<Iş> Işs { get; set; }
        public List<Tezgah> Tezgahs { get; set; }
        public List<Stok> Stoks { get; set; }
    }
}
