using Entities.Concrete.APIDtos;
using Entities.Concrete.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsnyc(string refreshToken);
        Task<Response<NoContent>> RevokeRefreshToken(string refreshToken);
        Response<ClientTokenDto> CreateTokenByClient(LoginClientDto loginClientDto);
    }
}
