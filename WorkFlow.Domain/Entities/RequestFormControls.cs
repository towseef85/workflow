using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Domain.Utils;

namespace WorkFlow.Domain.Entities
{
    public class RequestFormControls : BaseEntity
    {
        public string ControlName { get; set; }
        public string EngCaption { get; set; }
        public string ArbCaption { get; set; }
        public string ControlType { get; set; }
        public bool IsRequired { get; set; } = false;
        public string? ToolTip { get; set; }
        public string? ArbToolTip { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsHide { get; set; }
        public int RequestFormId { get; set; }
        public bool? HasDataSource { get; set; }
        public string? DataSourceType  { get; set; }
        public string? DataSource { get; set; }
        public virtual RequestForms RequestForms { get; set; }
       public ICollection<RequestControlConditions> ControlConditions { get; set; }
        public ICollection<RequestFormControlsData>? RequestFormControlsData { get; set; }
        public ICollection<ControlSelectData>? ControlSelectData { get; set; }
    }
}
