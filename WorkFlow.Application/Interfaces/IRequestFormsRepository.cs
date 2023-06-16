using WorkFlow.Application.Dtos.RequestFormsDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IRequestFormsRepository
    {
        Task<List<GetRequestFormsDto>> GetAllRequestForms();
        Task<GetRequestFormsDto> GetRequestFormsById(int id);
        Task<bool> AddRequestForms(PostRequestFormsDto requestFormsDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequestForms(PostRequestFormsDto requestFormsDto);
        Task<bool> DeleteRequestForms(int id);
    }
}
