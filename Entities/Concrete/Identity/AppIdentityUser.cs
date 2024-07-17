using Entities.Concrete.OtherEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperTools.EntityHelpers;

namespace Entities.Concrete.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public AppIdentityUser()
        {
            AddedDate = DateTime.Now;
            BanStatus = false;
            Status = true;
        }
        public DateTime? AddedDate { get; set; }
        public string? AddedUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdatedUserId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string CultureName { get; set; }
        public string? Image { get; set; }
        public int CountryId { get; set; }
        public string? Job { get; set; }
        public bool Status { get; set; }
        public bool BanStatus { get; set; }
        public DateTime? BanStart { get; set; }
        public DateTime? BanEnd { get; set; }
        public string? BanComment { get; set; }
        public bool IsDeleted { get; set; }
        //public int ProfileId { get; set; }

    }
}
