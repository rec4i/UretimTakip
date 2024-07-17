using Core.DataAccess.Abstract;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace DataAccess.Abstract
{
    public interface IUserRefreshTokenRepository : IEntityRepositoryBase<UserRefreshToken>
    {
    }
}
