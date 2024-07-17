using Entities.Concrete.VmBaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.UserDtos
{
    public class AddUserDto
    {
        public AddUserDto()
        {
            Image = "DefaultImage.png";
            Status = true;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Job { get; set; }
        public int CountryId { get; set; }
        public string CultureName { get; set; }
        public bool LockoutEnabled { get; set; }
        public string? Image { get; set; }
        public string? AddedUserId { get; set; }
        public bool Status { get; set; }
        public int ProfileId { get; set; }
    }
}
