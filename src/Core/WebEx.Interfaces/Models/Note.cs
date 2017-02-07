using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models
{
    public class Note : DomainBase
    {
        public string Description { get; set; }

        public string Text { get; set; }

        public Organization Organization { get; set; }

        public Person Person { get; set; }
    }
}
