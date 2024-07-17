using Entities.Concrete;
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
    public class SideBarMenuItemConfiguration : IEntityTypeConfiguration<SideBarMenuItem>
    {
        public void Configure(EntityTypeBuilder<SideBarMenuItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.IconCss).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(70);
            builder.ToTable("SideBarMenuItems");
        }
    }
}
