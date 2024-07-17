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
    public class SystemUserLogConfiguration : IEntityTypeConfiguration<SystemUserLog>
    {
        public void Configure(EntityTypeBuilder<SystemUserLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Log).IsRequired(true);
            builder.Property(x => x.IPAdress).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.SystemUserId).IsRequired(false).HasMaxLength(450);//lggin için false
            builder.Property(x => x.TrxResult).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.ActionName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.ControllerName).IsRequired(true).HasMaxLength(50);
            builder.ToTable("SystemUserLogs");
        }
    }
}
