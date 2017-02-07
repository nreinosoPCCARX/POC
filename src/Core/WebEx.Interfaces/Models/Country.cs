using System.Collections.Generic;

namespace WebEx.Interfaces.Models
{ 
    public class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            StateProvinces = new HashSet<StateProvince>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
