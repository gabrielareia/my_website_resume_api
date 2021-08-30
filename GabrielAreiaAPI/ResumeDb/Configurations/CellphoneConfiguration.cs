using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class CellphoneConfiguration : IEntityTypeConfiguration<Cellphone>
    {
        public void Configure(EntityTypeBuilder<Cellphone> builder)
        {
            builder
                .Property(c => c.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne<ContactInfo>()
                .WithMany(co => co.Cellphones)
                .HasForeignKey(c => c.ContactInfoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
