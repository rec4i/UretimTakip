using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configuration
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
             builder.HasKey(x => x.Id);

            builder
                .HasMany<AnnouncementRole>(g => g.AnnouncementRoles)
                .WithOne(s => s.Announcement)
                .HasForeignKey(s => s.AnnouncementId);

            builder
              .HasMany<AnnouncementUser>(g => g.AnnouncementUsers)
              .WithOne(s => s.Announcement)
              .HasForeignKey(s => s.AnnouncementId);


        }
    }
}
