using Entities.Concrete.OtherEntities;

namespace WebIU.Models.StokViewModels
{
    public class FiyatPaginatonModel
    {
        public List<Fiyat> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
