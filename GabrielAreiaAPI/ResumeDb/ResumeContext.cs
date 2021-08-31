using GabrielAreiaAPI.Models;
using GabrielAreiaAPI.ResumeDb.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GabrielAreiaAPI.ResumeDb
{
    public class ResumeContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Cellphone> Cellphones { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Experience> Experiences { get; set; }


        public ResumeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Resume>(new ResumeConfiguration());
            modelBuilder.ApplyConfiguration<Achievement>(new AchievementConfiguration());
            modelBuilder.ApplyConfiguration<Ability>(new AbilityConfiguration());
            modelBuilder.ApplyConfiguration<Course>(new CourseConfiguration());
            modelBuilder.ApplyConfiguration<Goal>(new GoalConfiguration());
            modelBuilder.ApplyConfiguration<Experience>(new ExperienceConfiguration());
           
            modelBuilder.ApplyConfiguration<ContactInfo>(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration<Cellphone>(new CellphoneConfiguration());
            modelBuilder.ApplyConfiguration<Email>(new EmailConfiguration());
            modelBuilder.ApplyConfiguration<Website>(new WebsiteConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
               
    }
}
