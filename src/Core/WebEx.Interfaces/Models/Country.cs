using System.Collections.Generic;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{ 
    public class Country : DomainBase
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
            StateProvinces = new HashSet<StateProvince>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<StateProvince> StateProvinces { get; set; }
    }
}
