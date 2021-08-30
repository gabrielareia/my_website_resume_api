namespace GabrielAreiaAPI.Models
{
    /// <summary>
    /// This class is only used to allow multiple cellphone numbers to be stored for each resume, 
    /// because EntityFramework can't store an array of strings.
    /// </summary>
    public class Cellphone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ContactInfoId { get; set; }
    }

    public static class CellphoneExtensions
    {
        public static string[] ToStringArray(this Cellphone[] cellphones)
        {
            string[] result = new string[cellphones.Length];

            for (int i = 0; i < cellphones.Length; i++)
            {
                result[i] = cellphones[i].Number;
            }

            return result;
        }
    }
}
