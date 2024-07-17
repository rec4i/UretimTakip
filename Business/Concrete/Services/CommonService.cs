using Business.Abstract.Services;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;

namespace Business.Concrete.Services
{
    public class CommonService : ICommonService
    {
        private readonly string _currentUserId;
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<AppIdentityUser> _userManager;
        public CommonService(IHttpContextAccessor context, UserManager<AppIdentityUser> userManager)
        {
            _context = context;
            if (IsAuthenticated())
                _currentUserId = _context.HttpContext.User.GetLoggedInUserId();
            else
                _currentUserId = "";
            _userManager = userManager;
        }
        public string CurrnetUserId()
        {
            return _currentUserId;
        }

        public ClaimsPrincipal? GetHttpUser()
        {
            return _context.HttpContext?.User;
        }

        public string GetUserName(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
                return "";
            return user.UserName;
        }

        public AppIdentityUser GetUser(string userId)
        {
            return _userManager.FindByIdAsync(userId).Result;
        }

        public List<AppIdentityUser> GetUsers()
        {
            return _userManager.Users.Where(p => !p.IsDeleted).ToList();
        }

        public bool IsAuthenticated()
        {
            return _context.HttpContext.User.Identity.IsAuthenticated;
        }
        public string ControllerName()
        {
            try
            {
                if (_context.HttpContext == null)
                    return "";
                var routeValues = ((dynamic)_context.HttpContext.Request).RouteValues as IReadOnlyDictionary<string, object>;
                return routeValues["Controller"].ToString();
            }
            catch
            {
                return null;
            }

            //return _context.HttpContext.Request.RouteValues["Controller"].ToString();

        }

        public string ActionName()
        {
            if (_context.HttpContext == null)
                return "";
            var routeValues = ((dynamic)_context.HttpContext.Request).RouteValues as IReadOnlyDictionary<string, object>;
            return routeValues["Action"].ToString();
            // return _context.HttpContext.Request.RouteValues["Action"].ToString();
        }

        public string IPAdress()
        {
            if (_context.HttpContext == null)
                return "";
            return _context.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
