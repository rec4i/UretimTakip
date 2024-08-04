using Entities.Concrete.OtherEntities;

namespace WebIU.Models.ProgramViewModels
{
    public class ProgramPaginationModel
    {
        public List<ProgramŞirketGrup> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
