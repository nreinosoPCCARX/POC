using System.Collections.Generic;

namespace WebEx.Interfaces.Models
{
    public class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string County { get; set; }

        public string PostalCode { get; set; }

        public int? StateProvnice_Id { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
