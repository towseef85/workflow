using WorkFlow.Application.Dtos.UsertypesDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<List<GetUserTypeDto>> GetAllUserTypes();
        Task<GetUserTypeDto> GetUserTypeById(int id);
        Task<bool> AddUserType(PostUserTypeDto UserTypeDto, CancellationToken cancellationToken);
        Task<bool> UpdateUserType(PostUserTypeDto UserTypeDto);
        Task<bool> DeleteUserType(int id);
    }
}
