namespace GabrielAreiaAPI.Models
{
    /// <summary>
    /// This class is only used to allow multiple email addresses to be stored for each resume, 
    /// because EntityFramework can't store an array of strings.
    /// </summary>
    public class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int ContactInfoId { get; set; }
    }

    public static class EmailExtensions
    {
        public static string[] ToStringArray(this Email[] emails)
        {
            string[] result = new string[emails.Length];

            for (int i = 0; i < emails.Length; i++)
            {
                result[i] = emails[i].Address;
            }

            return result;
        }
    }
}
