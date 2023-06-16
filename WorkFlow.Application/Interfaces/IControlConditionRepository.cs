using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IControlConditionRepository
    {
        Task<List<GetRequestFormControlConditionsDto>> GetAllControlConditions();
        Task<GetRequestFormControlConditionsDto> GetControlConditionById(int id);
        Task<List<GetRequestFormControlConditionsDto>> GetControlConditionByFormId(int id);
        Task<bool> AddControlCondition(PostRequestFormControlConditionDto ControlConditionDto, CancellationToken cancellationToken);
        Task<bool> UpdateControlCondition(PostRequestFormControlConditionDto ControlConditionDto);
        Task<bool> DeleteControlCondition(int id);
    }
}
