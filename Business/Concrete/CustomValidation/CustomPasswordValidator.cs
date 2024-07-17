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
    public class CustomPasswordValidator : IPasswordValidator<AppIdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppIdentityUser> manager, AppIdentityUser user, string password)
        {
            var identityError = new List<IdentityError>();
            string badLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                var error = new IdentityError { Code = "PasswordContainsUserName", Description = Messages.PasswordContainsUserName };
                identityError.Add(error);
            }
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (badLetters.Contains(password.Substring(i, 3)))
                {
                    var error = new IdentityError { Code = "PasswordContainsConsecutive", Description = Messages.PasswordContainsConsecutive };
                    identityError.Add(error);
                }
            }
            if (identityError.Count == 0)
                return Task.FromResult(IdentityResult.Success);
            else
                return Task.FromResult(IdentityResult.Failed(identityError.ToArray()));
        }
    }
}
