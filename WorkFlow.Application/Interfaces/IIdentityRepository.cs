using WorkFlow.Application.Dtos.IdentityDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IIdentityRepository
    {
        Task<List<GetRoleDto>> GetAllRoles();

        Task<List<GetUserDto>> GetAllUsers();
        Task<bool> AddUserRole(PostRoleDto postRoleDto, CancellationToken cancellationToken);

        Task<bool> AddUser(PostUserDto postUserDto, CancellationToken cancellationToken);

        Task<bool> EditUser(PostUserDto postUserDto, CancellationToken cancellationToken);

    }
}
