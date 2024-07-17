namespace Tools.Concrete.HelperClasses.EntityHelpers
{
    public class PaginationJsonValue<TEntity> where TEntity : class, new()
    {
        public List<TEntity> rows { get; set; }
        public int total { get; set; }
        public int totalNotFiltered { get; set; }
    }
}
