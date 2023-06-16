using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class UserType :BaseEntity
    {
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string? Remarks { get; set; }
        //public bool Deleted { get; set; }
        //public DateTime? DeleteDate { get; set; }
        //public ICollection<RequestFormControlConditionUserLevels> FormControlConditionUserLevels { get; set; }
    }
}
