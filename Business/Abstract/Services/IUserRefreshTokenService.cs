using Entities.Concrete.APIDtos;
using Entities.Concrete.Identity;
using Entities.Concrete.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IUserRefreshTokenService
    {
        UserRefreshToken GetRefreshToken(string userId);
        UserRefreshToken GetTokenByRefreshToken(string refreshToken);
        UserRefreshToken Add(AppIdentityUser user, TokenDto token);
        void Update(UserRefreshToken entity);
        void Delete(UserRefreshToken entity);
    }
}
