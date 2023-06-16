using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestConditionOperators : BaseEntity
    {
        public int ControlConditionsId { get; set; }
        public int FormControlId { get; set; }
        public string Operand { get; set; }
        public string Operator { get; set; }
        public float Value { get; set; }
        public virtual RequestControlConditions RequestControlConditions { get; set; }

    }
}
