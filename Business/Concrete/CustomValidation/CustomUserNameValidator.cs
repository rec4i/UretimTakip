using Business.Contants;
using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CustomValidation
{
    public class CustomUserNameValidator : IUserValidator<AppIdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppIdentityUser> manager, AppIdentityUser user)
        {
            string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var identityError = new List<IdentityError>();

            foreach (var digit in digits)
            {
                if (user.UserName[0].ToString() == digit)
                {
                    identityError.Add(new IdentityError
                    {
                        Description = Messages.UsernameCannotStartWithaDigit,
                        Code = "UsernameCannotStartWithaDigit"
                    });
                }
            }
            if (identityError.Count == 0)
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(identityError.ToArray()));

        }
    }
}
