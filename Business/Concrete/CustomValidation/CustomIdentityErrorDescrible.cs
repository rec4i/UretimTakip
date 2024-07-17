using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CustomValidation
{
    public class CustomIdentityErrorDescrible : IdentityErrorDescriber
    {
        //Hataların türkçeleştirilmesi işlemleri
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = $"{userName} kullanıcı adı geçersizdir!"
            };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = $"{email} mail adresi daha önce tanımlanmıştır!"
            };
        }
    }
}
