using WorkFlow.Application.Dtos.RequestFormControlsDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IRequestFormControlsRepository
    {
        Task<List<GetRequestFormControlsDto>> GetAllRequestFormControls();
        Task<GetRequestFormControlsDto> GetRequestFormControlsById(int id);
        Task<List<SelectData>> GetSelectDataForControl(int controlId);
        Task<bool> AddRequestFormControls(PostRequestFormControlsDto RequestFormControlsDto, CancellationToken cancellationToken);
        Task<bool> UpdateRequestFormControls(UpdateRequestFormControlsDto RequestFormControlsDto);
        Task<bool> DeleteRequestFormControls(int id);
    }
}
