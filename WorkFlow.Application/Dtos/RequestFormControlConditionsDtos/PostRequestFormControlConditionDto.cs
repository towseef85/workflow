using WorkFlow.Application.Dtos.RequestConditionOperatorsDtos;

namespace WorkFlow.Application.Dtos.RequestFormControlConditionsDtos
{
    public class PostRequestFormControlConditionDto
    {
        public int Id { get; set; }
        public string EngDescription { get; set; }
        public string ArbDescription { get; set; }
        public int EscalationHours { get; set; }
        public bool RestrictForm { get; set; }
        public int FormId { get; set; }
        public ICollection<PostRequestConditionOperatorsDto>? Operators { get; set; }
    }
}
