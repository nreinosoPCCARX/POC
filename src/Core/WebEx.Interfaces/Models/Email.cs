using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Email : DomainBase
    {
        public string EmailAddress { get; set; }

        public int EmailType { get; set; }

        public Organization Organization { get; set; }

        public Person Person { get; set; }
    }
}
