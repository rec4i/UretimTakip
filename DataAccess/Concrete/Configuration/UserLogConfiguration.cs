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
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Log).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.SystemUserId).IsRequired(true).HasMaxLength(450);
            builder.Property(x => x.ChangeUserId).IsRequired(true).HasMaxLength(450);
            builder.ToTable("UserLogs");
        }
    }
}
