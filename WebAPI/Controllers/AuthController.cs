using Business.Abstract.Services;
using Entities.Concrete.APIDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDto);
            return CreateActionResult(result);
        }

        //[HttpPost]
        //public IActionResult CreateTokenByClient(LoginClientDto loginClientDto)
        //{
        //    var result = _authenticationService.CreateTokenByClient(loginClientDto);
        //    return CreateActionResult(result);
        //}

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);
            return CreateActionResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authenticationService.CreateTokenByRefreshTokenAsnyc(refreshTokenDto.RefreshToken);
            return CreateActionResult(result);
        }
    }
}
