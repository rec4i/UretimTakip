namespace Tools.Concrete.HelperClasses.EntityHelpers
{
    public class PaginatonParameters<TEntity> where TEntity : class, new()
    {
        public string Search { get; set; }
        public string Order { get; set; }
        public string Sort { get; set; }
        public int Ofsset { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
