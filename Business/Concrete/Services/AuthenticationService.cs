using Business.Abstract.Services;
using Business.Contants;
using Entities.Concrete.APIDtos;
using Entities.Concrete.Identity;
using Entities.Concrete.Response;
using Entities.Concrete.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly List<Client> _clients;
        private readonly IUserRefreshTokenService _userRefreshTokenService;

        public AuthenticationService(
            UserManager<AppIdentityUser> userManager,
            ITokenService tokenService,
            IOptions<List<Client>> optionsClients,
            IUserRefreshTokenService userRefreshTokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _clients = optionsClients.Value;
            _userRefreshTokenService = userRefreshTokenService;
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
                throw new ArgumentException(nameof(loginDto));
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Response<TokenDto>.Fail(Messages.UsernamePasswordIncorrect, 400);

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Response<TokenDto>.Fail(Messages.UsernamePasswordIncorrect, 400);

            var token = _tokenService.CreateToken(user);
            var refreshToken = _userRefreshTokenService.GetRefreshToken(user.Id);
            if (refreshToken == null)
            {
                refreshToken = _userRefreshTokenService.Add(user, token);
            }
            else
            {
                refreshToken.Code = token.RefreshToken;
                refreshToken.Expiration = token.RefreshTokenExpiration;
                _userRefreshTokenService.Update(refreshToken);
            }

            return Response<TokenDto>.Success(token, 200);
        }

        public Response<ClientTokenDto> CreateTokenByClient(LoginClientDto loginClientDto)
        {
            var client = _clients.SingleOrDefault(p => p.Id == loginClientDto.ClientId && p.Secret == loginClientDto.ClientSecret);
            if (client == null)
                return Response<ClientTokenDto>.Fail(Messages.ClientNotFound, 400);
            var token = _tokenService.CreateTokenByClient(client);
            return Response<ClientTokenDto>.Success(token, 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshTokenAsnyc(string refreshToken)
        {
            var existRefreshToken = _userRefreshTokenService.GetTokenByRefreshToken(refreshToken);
            if (existRefreshToken == null)
                return Response<TokenDto>.Fail(Messages.RefreshTokenNotFound, 400);
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null)
                return Response<TokenDto>.Fail(Messages.UserIdNotFound, 400);

            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            existRefreshToken.Code = tokenDto.RefreshToken;
            _userRefreshTokenService.Update(existRefreshToken);
            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoContent>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = _userRefreshTokenService.GetTokenByRefreshToken(refreshToken);
            if (existRefreshToken == null)
                return Response<NoContent>.Fail(Messages.RefreshTokenNotFound, 400);
            _userRefreshTokenService.Delete(existRefreshToken);
            return Response<NoContent>.Success(200);
        }
    }
}
