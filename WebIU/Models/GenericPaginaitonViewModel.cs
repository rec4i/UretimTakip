using Entities.Abstract;

namespace WebIU.Models
{
    public class GenericPaginaitonViewModel<TEntity>
    {
        public List<TEntity> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
