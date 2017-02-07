namespace WebEx.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Website
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int? Organization_Id { get; set; }

        public int? Person_Id { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }
    }
}
