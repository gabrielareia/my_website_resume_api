namespace GabrielAreiaAPI.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Company { get; set; }
        public string Field { get; set; }
        public string Role { get; set; }
        public int YearStart { get; set; }
        public int? YearEnd { get; set; }
        public string Notes { get; set; }
        public string CompanyWebsite { get; set; }
        public int ResumeId { get; set; }
    }
}
