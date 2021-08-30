
using System;
using System.Collections.Generic;
using System.Linq;

namespace GabrielAreiaAPI.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int YearBirth { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public ContactInfo Contact { get; set; }
        public int? ContactId { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Ability> Abilities { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Experience> Experiences { get; set; }

        public void UpdateId(int id)
        {
            Id = id;

            if (Goals != null)
            {
                foreach (Goal goal in Goals)
                {
                    goal.ResumeId = Id;
                }
            }

            if (Courses != null)
            {
                foreach (Course course in Courses)
                {
                    course.ResumeId = Id;
                }
            }

            if (Abilities != null)
            {
                foreach (Ability ability in Abilities)
                {
                    ability.ResumeId = Id;
                }
            }

            if (Achievements != null)
            {
                foreach (Achievement achievement in Achievements)
                {
                    achievement.ResumeId = Id;
                }
            }

            if (Experiences != null)
            {
                foreach (Experience experience in Experiences)
                {
                    experience.ResumeId = Id;
                }
            }
        }
    }
    public class ResumeApi
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int YearBirth { get; set; }
        public string PictureAddress { get; set; }
        public string Description { get; set; }
        public ContactInfoApi Contact { get; set; }
        public string[] Goals { get; set; }
        public CourseApi[] Courses { get; set; }
        public AbilityApi[] Abilities { get; set; }
        public Achievement[] Achievements { get; set; }
        public Experience[] Experiences { get; set; }
    }

    public static class ResumeExtensions
    {
        public static ResumeApi ToApi(this Resume resume)
        {
            if (resume == null)
                return null;

            var result = new ResumeApi()
            {
                Id = resume.Id,
                FullName = resume.FullName,
                YearBirth = resume.YearBirth,
                PictureAddress = $"/api/resume/{resume.Id}/image",
                Description = resume.Description,
                Contact = resume.Contact.ToApi(),
                Goals = resume.Goals.ToStringArray(),
                Abilities = resume.Abilities.ToApiArray(),
                Courses = resume.Courses.ToApiArray(),
                Achievements = resume.Achievements == null ? null : resume.Achievements.ToArray(),
                Experiences = resume.Experiences == null ? null : resume.Experiences.ToArray()
            };

            return result;
        }
    }
}
