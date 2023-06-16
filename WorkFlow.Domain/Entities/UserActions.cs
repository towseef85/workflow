using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class UserActions : BaseEntity
    {
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public string? Remarks { get; set; }
        public bool IsApproval { get; set; }
        public bool IsReject { get; set; }
        public bool IsDelegate { get; set; }
    }
}
