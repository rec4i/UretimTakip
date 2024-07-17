using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebIU.Models.User
{
    public class AddUserViewModel
    {
        public bool MailSend { get; set; }
        public List<string> RoleNames { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        public IFormFile? ImageFile { get; set; }
        public List<IdentityRole>? Roles { get; set; }
        public AddUserDto User { get; set; }
        public IEnumerable<Country>? Countries { get; set; }
        public List<Culture>? Cultures { get; internal set; }
        public int ImplementerId { get; set; }
        public bool IsSuperAdmin { get; internal set; }
        //public List<Entities.Concrete.OtherEntities.Profile>? Profiles { get; set; }
    }
}
