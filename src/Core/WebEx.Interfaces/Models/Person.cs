using System;
using System.Collections.Generic;

namespace WebEx.Interfaces.Models
{
    public class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Notes = new HashSet<Note>();
            Phones = new HashSet<Phone>();
            Websites = new HashSet<Website>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public int Sex { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
    }
}
