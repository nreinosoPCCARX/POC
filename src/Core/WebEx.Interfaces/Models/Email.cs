namespace WebEx.Interfaces.Models
{
    public class Email
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public int EmailType { get; set; }

        public int? Organization_Id { get; set; }

        public int? Person_Id { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }
    }
}
