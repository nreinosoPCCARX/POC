using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebEx.Interfaces.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public int City_Id { get; set; }

        public int Country_Id { get; set; }

        public int StateProvince_Id { get; set; }

        public int? Organization_Id { get; set; }

        public int? Person_Id { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Person Person { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
