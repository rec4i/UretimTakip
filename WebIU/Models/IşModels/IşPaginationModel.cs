using Entities.Concrete.OtherEntities;

namespace WebIU.Models.IşModels
{
    public class IşPaginationModel
    {
        public List<Iş> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
