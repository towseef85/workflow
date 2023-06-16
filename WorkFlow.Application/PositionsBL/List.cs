using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.PositionsBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetPositionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetPositionDto>>>
        {
            private readonly IPositionsRepository _iPositionRepo;
            public Handler(IPositionsRepository iPositionRepo)
            {
                _iPositionRepo = iPositionRepo;
            }

            public async Task<Result<List<GetPositionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Positions = await _iPositionRepo.GetAllPositions();
                return Result<List<GetPositionDto>>.Success(Positions);
            }
        }
    }
}
