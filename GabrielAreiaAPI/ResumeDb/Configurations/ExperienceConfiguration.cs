using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder
                .Property(e => e.Company)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(e => e.Field)
                .HasMaxLength(100);

            builder
                .Property(e => e.Role)
                .HasMaxLength(120)
                .IsRequired();

            builder
                .Property(e => e.YearStart)
                .IsRequired();

            builder
                .Property(e => e.YearEnd);

            builder
                .Property(e => e.Notes)
                .HasMaxLength(1000);

            builder
                .Property(c => c.CompanyWebsite)
                .HasMaxLength(150);

            builder
                .HasOne<Resume>()
                .WithMany(r => r.Experiences)
                .HasForeignKey(c => c.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
