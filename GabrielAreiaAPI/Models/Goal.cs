using System.Collections.Generic;
using System.Linq;

namespace GabrielAreiaAPI.Models
{
    /// <summary>
    /// This class is only used to allow multiple goals to be stored for each resume, 
    /// because EntityFramework can't store an array of strings.
    /// </summary>
    public class Goal
    {
        public int Id { get; set; }
        public string MyGoal { get; set; }        
        public int ResumeId { get; set; }
    }

    public static class GoalExtensions
    {
        public static string[] ToStringArray(this ICollection<Goal> goals)
        {
            if (goals == null) return null;

            string[] result = new string[goals.Count];

            for (int i = 0; i < goals.Count; i++)
            {
                result[i] = goals.ToArray()[i].MyGoal;
            }

            return result;
        }

    }
}
