using Entities.Concrete.OtherEntities;

namespace WebIU.Models.SorumluKullanıcıViewModels
{
    public class SorumluKullanıcıPaginaitonModel
    {
        public List<SorumluKullanıcı> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
