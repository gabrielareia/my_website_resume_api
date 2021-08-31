using System.Collections.Generic;
using System.Linq;

namespace GabrielAreiaAPI.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Subject { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public int ResumeId { get; set; }
    }

    /// <summary>
    /// When requesting to the API the user won't receive an image, but the address to that image.
    /// </summary>
    public class AbilityApi
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Subject { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string LogoAddress { get; set; }
    }

    public static class AbilityExtensions
    {
        public static AbilityApi ToApi(this Ability ability)
        {
            return new AbilityApi()
            {
                Id = ability.Id,
                Order = ability.Order,
                Subject = ability.Subject,
                Experience = ability.Experience,
                Description = ability.Description,
                LogoAddress = ability.Logo == null ? null : $"/api/abilities/{ability.Id}/logo"
            };
        }

        public static AbilityApi[] ToApiArray(this ICollection<Ability> abilities)
        {
            if (abilities == null || abilities.Count == 0) return null;

            AbilityApi[] result = new AbilityApi[abilities.Count];

            for (int i = 0; i < abilities.Count; i++)
            {
                result[i] = abilities.ToArray()[i].ToApi();
            }

            return result;
        }
    }
}