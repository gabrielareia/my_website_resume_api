using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder
                .Property(c => c.Address)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .HasOne<ContactInfo>()
                .WithMany(co => co.Websites)
                .HasForeignKey(w => w.ContactInfoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
