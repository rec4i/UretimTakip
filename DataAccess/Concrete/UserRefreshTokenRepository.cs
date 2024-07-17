using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRefreshTokenRepository : EntityReposiyoryBase<UserRefreshToken, AppIdentityDbContext>, IUserRefreshTokenRepository
    {

    }
}
