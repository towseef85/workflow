using WorkFlow.Application.Dtos.PositionDtos;

namespace WorkFlow.Application.Interfaces
{
    public interface IPositionsRepository
    {
        Task<List<GetPositionDto>> GetAllPositions();
        Task<GetPositionDto> GetPositionById(int id);
        Task<bool> AddPosition(PostPositionDto PositionDto, CancellationToken cancellationToken);
        Task<bool> UpdatePosition(PostPositionDto PositionDto);
        Task<bool> DeletePosition(int id);
    }
}
