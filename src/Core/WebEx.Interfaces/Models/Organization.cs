using System.Collections.Generic;

namespace WebEx.Interfaces.Models
{
    public class Organization
    {
        public Organization()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Notes = new HashSet<Note>();
            Phones = new HashSet<Phone>();
            Websites = new HashSet<Website>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
    }
}
