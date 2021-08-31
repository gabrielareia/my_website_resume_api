using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder
                .Property(r => r.FullName)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(r => r.Language)
                .HasMaxLength(100);

            builder
                .Property(r => r.YearBirth)
                .IsRequired();

            builder
                .Property(r => r.Description)
                .HasMaxLength(3000);

            builder.Ignore(r => r.Contact);

            builder
                .HasOne(r => r.Contact)
                .WithMany()
                .HasForeignKey(r => r.ContactId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);

        }
    }
}
