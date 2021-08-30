using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder
                .Property(c => c.Skype)
                .HasMaxLength(100);

            builder
                .Property(c => c.Discord)
                .HasMaxLength(100);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }

}
