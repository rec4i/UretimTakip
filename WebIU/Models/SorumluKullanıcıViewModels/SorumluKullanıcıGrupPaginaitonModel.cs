using Entities.Concrete.OtherEntities;

namespace WebIU.Models.SorumluKullanıcıViewModels
{
    public class SorumluKullanıcıGrupPaginaitonModel
    {
        public List<SorumluKullanıcıGrup> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }

    }
}
