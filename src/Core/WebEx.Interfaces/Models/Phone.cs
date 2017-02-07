namespace WebEx.Interfaces.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public int PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string Extension { get; set; }

        public string CountryCode { get; set; }

        public int? Organization_Id { get; set; }

        public int? Person_Id { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }
    }
}
