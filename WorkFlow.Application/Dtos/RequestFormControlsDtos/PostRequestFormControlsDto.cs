using WorkFlow.Domain.Utils;

namespace WorkFlow.Application.Dtos.RequestFormControlsDtos
{
    public class PostRequestFormControlsDto
    {
        public string ControlName { get; set; }
        public string EngCaption { get; set; }
        public string ArbCaption { get; set; }
        public string ControlType { get; set; }
        public bool? HasDataSource { get; set; } = false;
        public bool IsRequired { get; set; } = false;
        public string DataSourceType { get; set; }
        public string? DataSource { get; set; }
        public string? ToolTip { get; set; }
        public string? ArbToolTip { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsHide { get; set; }=false;
        public int RequestFormId { get; set; }
        public ICollection<SelectData>? SelectData { get; set; }
    }

    
}
