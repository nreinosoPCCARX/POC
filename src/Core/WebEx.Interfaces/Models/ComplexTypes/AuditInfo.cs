using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEx.Interfaces.Models.ComplexTypes
{
    [ComplexType]
    public class AuditInfo
    {
        public string UserName { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
