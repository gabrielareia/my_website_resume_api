using GabrielAreiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.ResumeDb.Configurations
{
    public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder
                .Property(a => a.Subject)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(a => a.Experience)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(a => a.Description)
                .HasMaxLength(1000);

            builder
                .HasOne<Resume>()
                .WithMany(r => r.Abilities)
                .HasForeignKey(a => a.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property<DateTime>("LastUpdate")
                .HasColumnType("timestamp")
                .HasDefaultValueSql(SQL_Constants.GetDate);
        }
    }
}
