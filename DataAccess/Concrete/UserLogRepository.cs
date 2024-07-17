using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete;
using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Concrete
{
    public class UserLogRepository : EntityReposiyoryBase<UserLog, AppIdentityDbContext>, IUserLogRepository
    {

    }
}
