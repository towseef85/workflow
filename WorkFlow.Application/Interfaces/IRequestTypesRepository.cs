using WorkFlow.Application.Dtos.RequestTypeDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IRequestTypesRepository
    {
        Task<List<GetRequestTypeDto>> GetAllRequestTypes();
        Task<GetRequestTypeDto> GetRequestTypeById(int id);
        Task<bool> AddRequestType(PostRequestTypeDto requestTypeDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequestType(PostRequestTypeDto requestTypeDto);
        Task<bool> DeleteRequestType(int id);
    }
}
