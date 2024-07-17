using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configuration
{
    public class AnnouncementRoleConfiguration : IEntityTypeConfiguration<AnnouncementRole>
    {
        public void Configure(EntityTypeBuilder<AnnouncementRole> builder)
        {

            builder.HasKey(x => x.Id);
            
        }
    }
}
