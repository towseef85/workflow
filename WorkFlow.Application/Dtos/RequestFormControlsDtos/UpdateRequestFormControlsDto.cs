using WorkFlow.Domain.Utils;

namespace WorkFlow.Application.Dtos.RequestFormControlsDtos
{
    public class UpdateRequestFormControlsDto
    {
        public int Id { get; set; }
        public string ControlName { get; set; }
        public string EngCaption { get; set; }
        public string ArbCaption { get; set; }
        public ControlType ControlType { get; set; }
        public bool? HasDataSource { get; set; } = false;
        public bool IsRequired { get; set; } = false;
        public DataSourceType? DataSourceType { get; set; }
        public string? DataSource { get; set; }
        public string? ToolTip { get; set; }
        public string? ArbToolTip { get; set; }
        public bool? IsNumeric { get; set; }
        public bool? IsHide { get; set; } = false;
        public int RequestFormId { get; set; }
    }
}
