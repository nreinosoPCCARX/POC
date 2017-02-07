using System.Collections.Generic;

namespace WebEx.Interfaces.Models
{
    public class StateProvince
    {
        public StateProvince()
        {
            Addresses = new HashSet<Address>();
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Country_Id { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual Country Country { get; set; }
    }
}
