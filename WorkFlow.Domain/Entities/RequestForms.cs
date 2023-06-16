using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestForms : BaseEntity
    {
     
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string? EngDescription { get; set; }

        public string? ArbDescription { get; set; }
        public int? Rank { get; set; }

      
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public ICollection<RequestFormControls> FormControls { get; set; }
        public ICollection<RequestControlConditions> ControlConditions { get; set; }
    }
}
