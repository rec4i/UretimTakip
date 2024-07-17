using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.VmDtos.RoleDtos
{
    public class EditPermissionInRoleDto
    {
        public EditPermissionInRoleDto()
        {
            IsSelected = false;
        }
        public string Permission { get; set; }
        public bool IsSelected { get; set; }
    }
}
