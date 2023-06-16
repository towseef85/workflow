using WorkFlow.Application.Dtos.RequestConditionOperatorsDtos;
using WorkFlow.Application.Dtos.RequestFormsDtos;

namespace WorkFlow.Application.Dtos.RequestFormControlConditionsDtos
{
    public class GetRequestFormControlConditionsDto
    {
        public int Id { get; set; }
        public string EngDescription { get; set; }
        public string ArbDescription { get; set; }
        public int EscalationHours { get; set; }
        public bool RestrictForm { get; set; }
        public int FormId { get; set; }
        public virtual GetRequestFormShortDto GetRequestForm { get; set; }
        public ICollection<GetRequestConditionOperatorsDto>? Operators { get; set; }
       
    }
}
