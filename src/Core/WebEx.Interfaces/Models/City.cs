using System.Collections.Generic;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class City : DomainBase
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public string Name { get; set; }

        public string County { get; set; }

        public string PostalCode { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public StateProvince StateProvince { get; set; }
    }
}
