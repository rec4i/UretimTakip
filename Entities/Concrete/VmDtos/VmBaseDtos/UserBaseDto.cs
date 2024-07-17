using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmBaseDtos
{
    public class UserBaseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Job { get; set; }
        public int CountryId { get; set; }
        public string CultureName { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }

    }
}
