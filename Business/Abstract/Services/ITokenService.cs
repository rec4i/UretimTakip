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
    public interface ITokenService
    {
        TokenDto CreateToken(AppIdentityUser user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
