using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebEx.Interfaces.Models.Base;

namespace WebEx.Interfaces.Models.ComplexTypes
{
    [ComplexType]
    public class AuditInfo : ComplexTypeBase
    {
        public string UserName { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
