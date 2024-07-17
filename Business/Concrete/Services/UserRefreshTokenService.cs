using Business.Abstract.Services;
using DataAccess.Abstract;
using Entities.Concrete.APIDtos;
using Entities.Concrete.Identity;
using Entities.Concrete.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class UserRefreshTokenService : IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        public UserRefreshTokenService(IUserRefreshTokenRepository userRefreshTokenRepository)
        {
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public UserRefreshToken Add(AppIdentityUser user, TokenDto token)
        {
            _userRefreshTokenRepository.Add(new UserRefreshToken
            {
                UserId=user.Id,
                Code=token.RefreshToken,
                Expiration=token.RefreshTokenExpiration
            });
            return GetRefreshToken(user.Id);
        }

        public void Delete(UserRefreshToken entity)
        {
            _userRefreshTokenRepository.Delete(entity,true);
        }

        public UserRefreshToken GetRefreshToken(string userId)
        {
            return _userRefreshTokenRepository.Get(p => p.UserId == userId);
        }

        public UserRefreshToken GetTokenByRefreshToken(string refreshToken)
        {
            return _userRefreshTokenRepository.Get(p => p.Code == refreshToken);
        }

        public void Update(UserRefreshToken entity)
        {
            _userRefreshTokenRepository.Update(entity);
        }
    }
}
