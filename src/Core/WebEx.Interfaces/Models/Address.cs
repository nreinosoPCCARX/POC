using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Address : DomainBase
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public City City { get; set; }

        public Country Country { get; set; }

        public Organization Organization { get; set; }

        public Person Person { get; set; }

        public StateProvince StateProvince { get; set; }
    }
}
