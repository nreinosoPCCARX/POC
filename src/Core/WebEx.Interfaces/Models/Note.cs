namespace WebEx.Interfaces.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Text { get; set; }

        public int? Organization_Id { get; set; }

        public int? Person_Id { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }
    }
}
