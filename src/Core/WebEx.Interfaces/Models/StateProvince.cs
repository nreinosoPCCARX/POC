using System.Collections.Generic;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class StateProvince : DomainBase
    {
        public StateProvince()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<City> Cities { get; set; }

        public Country Country { get; set; }
    }
}
