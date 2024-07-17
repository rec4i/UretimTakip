using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperTools.EntityHelpers;

namespace Entities.Concrete.BaseEntities
{
    public class BaseEntityTwo : IEntity
    {
        public BaseEntityTwo()
        {
            Status = true;
        }
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string? AddedUserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
    }
}
