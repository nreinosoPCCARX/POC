using System;
using System.Collections.Generic;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Person : DomainBase
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Notes = new HashSet<Note>();
            Phones = new HashSet<Phone>();
            Websites = new HashSet<Website>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public int Sex { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ICollection<Website> Websites { get; set; }
    }
}
