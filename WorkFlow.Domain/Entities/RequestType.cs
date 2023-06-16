using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestType : BaseEntity
    {
      
        public string EngName { get; set; }
        public string ArbName { get; set; }
        public ICollection<RequestForms> RequestForms { get; set; }


    }
}
