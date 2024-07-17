using Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface ICommonService
    {
        string CurrnetUserId();
        string GetUserName(string userId);
        AppIdentityUser GetUser(string userId);
        ClaimsPrincipal GetHttpUser();
        List<AppIdentityUser> GetUsers();
        bool IsAuthenticated();
        string ControllerName();
        string ActionName();
        string IPAdress();

    }
}
