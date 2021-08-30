using System.Collections.Generic;

namespace GabrielAreiaAPI.Models
{
    /// <summary>
    /// Contact information is stored here. This will create a different table to store this information separately.
    /// </summary>
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Skype { get; set; }
        public string Discord { get; set; }
        //public ICollection<Resume> Resumes { get; set; }
        public ICollection<Email> EmailAddresses { get; set; }
        public ICollection<Cellphone> Cellphones { get; set; }
        public ICollection<Website> Websites { get; set; }

        public void UpdateId(int id)
        {
            Id = id;

            foreach (Email email in EmailAddresses)
            {
                email.ContactInfoId = Id;
            }

            foreach (Cellphone cellphone in Cellphones)
            {
                cellphone.ContactInfoId = Id;
            }

            foreach (Website website in Websites)
            {
                website.ContactInfoId = Id;
            }

        }
    }

    /// <summary>
    /// This class will be used to display information when requested to the API by the user.
    /// Instead of receiving a arrays of objects with only one property in them they will receive arrays of strings
    /// that are easier to read and manage in the front-end
    /// </summary>
    public class ContactInfoApi
    {
        public int Id { get; set; }
        public string Skype { get; set; }
        public string Discord { get; set; }
        public string[] EmailAddresses { get; set; }
        public string[] Cellphones { get; set; }
        public string[] Websites { get; set; }
    }

    public static class ContactExtensions
    {
        public static ContactInfoApi ToApi(this ContactInfo contactInfo)
        {
            if (contactInfo == null)
                return null;

            var result = new ContactInfoApi()
            {
                Id = contactInfo.Id,
                Skype = contactInfo.Skype,
                Discord = contactInfo.Discord
            };


            return result;
        }

    }
}
