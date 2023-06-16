using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestControlConditions : BaseEntity
    {
        public string EngDescription { get; set; }
        public string? ArbDescription { get; set; }
        public int EscalationHours { get; set; }
        public bool RestrictForm { get; set; } 
        public int FormId { get; set; }
        public virtual RequestForms RequestForms { get; set; }
        public ICollection<RequestConditionOperators> RequestConditionOperators { get; set; }
        public ICollection<RequestConditionUsers> RequestConditionUsers { get; set; }



    }
}
