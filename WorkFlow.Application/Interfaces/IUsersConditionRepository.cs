using WorkFlow.Application.Dtos.UserConditionDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IUsersConditionRepository
    {
        Task<List<GetUsersConditionDto>> GetAllUsersCondtions();
        Task<GetUsersConditionDto> GetUsersCondtionById(int id);
        Task<bool> AddUsersCondition(PostUserConditionDto UserConditionDto, CancellationToken cancellationToken);
        Task<bool> UpdateUsersCondition(UserConditionDto UserConditionDto);
        Task<bool> DeleteUsersCondition(int id);
    }
}
