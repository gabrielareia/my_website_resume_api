using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GabrielAreiaAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public string Subject { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string Description { get; set; }
        public byte[] CertificateImage { get; set; }
        public string CertificateAddress { get; set; }
        public byte[] Logo { get; set; }
        public string InstitutionWebsite { get; set; }
        public int ResumeId { get; set; }
    }

    /// <summary>
    /// When requesting to the API the user won't receive an image, but the address to that image.
    /// </summary>
    public class CourseApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Institution { get; set; }
        public string Subject { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string Description { get; set; }
        public string CertificateImageAddress { get; set; }
        public string CertificateAddress { get; set; }
        public string LogoAddress { get; set; }
        public string InstitutionWebsite { get; set; }
    }
    public static class CourseExtensions
    {
        public static CourseApi ToApi(this Course course)
        {
            return new CourseApi()
            {
                Id = course.Id,
                Name = course.Name,
                Institution = course.Institution,
                Subject = course.Subject,
                YearStart = course.YearStart,
                YearEnd = course.YearEnd,
                Description = course.Description,
                CertificateImageAddress = $"/api/courses/{course.Id}/certificate",
                CertificateAddress = course.CertificateAddress,
                LogoAddress = $"/api/courses/{course.Id}/logo",
                InstitutionWebsite = course.InstitutionWebsite
            };
        }
        public static CourseApi[] ToApiArray(this ICollection<Course> courses)
        {
            if (courses == null || courses.Count == 0) return null;

            CourseApi[] result = new CourseApi[courses.Count];

            for (int i = 0; i < courses.Count; i++)
            {
                result[i] = courses.ToArray()[i].ToApi();
            }

            return result;
        }
    }
}
