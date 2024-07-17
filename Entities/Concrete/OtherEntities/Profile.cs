using Entities.Concrete.BaseEntities;

namespace Entities.Concrete.OtherEntities
{
    public class Profile : BaseEntity
    {
        public string? UserId { get; set; }
        public string ProfileName { get; set; }
    }
}
