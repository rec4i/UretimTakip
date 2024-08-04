using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ProgramViewModels
{
    public class ProgramKullanıcıPaginationModel
    {
        public List<ProgramŞirketKullanıcı> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
