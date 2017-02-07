using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Website : DomainBase
    {
        public string Url { get; set; }

        public string Description { get; set; }

        public Organization Organization { get; set; }

        public Person Person { get; set; }
    }
}
