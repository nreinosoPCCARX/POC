using System.Collections.Generic;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Organization : DomainBase
    {
        public Organization()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Notes = new HashSet<Note>();
            Phones = new HashSet<Phone>();
            Websites = new HashSet<Website>();
        }

        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ICollection<Website> Websites { get; set; }
    }
}
