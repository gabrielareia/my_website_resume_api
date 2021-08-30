namespace GabrielAreiaAPI.Models
{
    /// <summary>
    /// This class is only used to allow multiple websites to be stored for each resume, 
    /// because EntityFramework can't store an array of strings.
    /// </summary>
    public class Website
    {
        public int Id { get; set; }
        public string Address { get; set; }        
        public int ContactInfoId { get; set; }
    }

    public static class WebsiteExtensions
    {
        public static string[] ToStringArray(this Website[] websites)
        {
            string[] result = new string[websites.Length];

            for (int i = 0; i < websites.Length; i++)
            {
                result[i] = websites[i].Address;
            }

            return result;
        }
    }
}
