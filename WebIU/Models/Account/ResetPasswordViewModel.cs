using System.ComponentModel.DataAnnotations;

namespace WebIU.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
