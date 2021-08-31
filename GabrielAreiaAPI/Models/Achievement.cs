namespace GabrielAreiaAPI.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }        
        public int ResumeId { get; set; }

    }

}