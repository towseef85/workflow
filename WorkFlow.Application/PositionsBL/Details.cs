using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.PositionsBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetPositionDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetPositionDto>>
        {
            private readonly IPositionsRepository _iPositionRepo;
            public Handler(IPositionsRepository iPositionRepo)
            {
                _iPositionRepo = iPositionRepo;
            }

            public async Task<Result<GetPositionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Position = await _iPositionRepo.GetPositionById(request.Id);

                return Result<GetPositionDto>.Success(Position);
            }
        }
    }
}
