using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder
                .Property(a => a.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(a => a.Year)
                .IsRequired();

            builder
                .Property(a => a.Description)
                .HasMaxLength(1000);

            builder
                .HasOne<Resume>()
                .WithMany(r => r.Achievements)
                .HasForeignKey(a => a.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
