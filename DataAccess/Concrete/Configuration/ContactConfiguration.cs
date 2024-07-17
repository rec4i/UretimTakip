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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Subject).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.SubjecTtype).IsRequired().HasMaxLength(20);
            builder.ToTable("Contacts");
        }
    }
}
