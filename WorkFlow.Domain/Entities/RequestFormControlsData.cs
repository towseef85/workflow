using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlow.Domain.Entities
{
    public class RequestFormControlsData : BaseEntity
    {
        public int ControlId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual RequestFormControls? FormControls { get; set; }
    }
}
