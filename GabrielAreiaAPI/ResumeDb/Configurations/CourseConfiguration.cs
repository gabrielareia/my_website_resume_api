using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Institution)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.Subject)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.YearStart)
                .IsRequired();

            builder
                .Property(c => c.YearEnd)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(1000);

            builder
                .Property(c => c.CertificateAddress)
                .HasMaxLength(500);

            builder
                .Property(c => c.InstitutionWebsite)
                .HasMaxLength(150);

            builder
                .HasOne<Resume>()
                .WithMany(r => r.Courses)
                .HasForeignKey(c => c.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
