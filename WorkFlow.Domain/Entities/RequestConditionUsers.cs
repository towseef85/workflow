using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestConditionUsers : BaseEntity
    {
        public int RequestConditionId { get; set; }
        public string? UserId { get; set; }
        public string? UserTypeId { get; set; }
        public int PriorityLevel { get; set; }
        public int UserActionId { get; set; }
        public bool isFinal { get; set; }
        public string? DataSource { get; set; }
        public  ICollection<RequestControlConditions> RequestControlConditions { get; set; }

    }
}
