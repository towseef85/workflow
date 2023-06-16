using WorkFlow.Application.Dtos.RequestFormsDtos;
using WorkFlow.Domain.Utils;

namespace WorkFlow.Application.Dtos.RequestFormControlsDtos
{
    public class GetRequestFormControlsDto
    {
        public int Id { get; set; }
        public string ControlName { get; set; }
        public string EngCaption { get; set; }
        public string ArbCaption { get; set; }
        public string ControlType { get; set; }
        public bool IsRequired { get; set; } = false;
        public bool? HasDataSource { get; set; }
        public string DataSourceType { get; set; }
        public string? DataSource { get; set; }
        public string? ToolTip { get; set; }
        public string? ArbToolTip { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsHide { get; set; }
        public bool Deleted { get; set; }
        public int RequestFormId { get; set; }
        public virtual GetRequestFormShortDto RequestForm { get; set; }
    }
}
