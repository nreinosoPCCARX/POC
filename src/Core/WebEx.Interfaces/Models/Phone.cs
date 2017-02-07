using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Phone : DomainBase
    {
        public int PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string Extension { get; set; }

        public string CountryCode { get; set; }

        public Organization Organization { get; set; }

        public Person Person { get; set; }
    }
}
