using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;

namespace Business.Concrete.Contants
{
    public class CurrnetInformationClass
    {

        private static IHttpContextAccessor _context;
        public static void SetHttpContextAccessor(IHttpContextAccessor context)
        {
            _context = context;
        }

        public static string IdTest()
        {
            return _context.HttpContext.User.GetLoggedInUserId();
        }
    }
}
