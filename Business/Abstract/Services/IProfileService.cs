using Entities.Concrete.OtherEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IProfileService
    {
        Profile Add(Profile entity);

        void Update(Profile entity);

        void Delete(int Id);
        Profile GetUserProfile(string UserId);

        List<Profile> GetAll(Expression<Func<Profile, bool>> filter = null);

    }
}
