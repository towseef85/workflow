using WorkFlow.Application.Dtos.UserActionDto;

namespace WorkFlow.Application.Interfaces
{
    public interface IUserActionsRepository
    {
        Task<List<GetUserActionDto>> GetAllUserActions();
        Task<GetUserActionDto> GetUserActionById(int id);
        Task<bool> AddUserAction(PostUserActionDto UserActionDto, CancellationToken cancellationToken);
        Task<bool> UpdateUserAction(PostUserActionDto UserActionDto);
        Task<bool> DeleteUserAction(int id);
    }
}
