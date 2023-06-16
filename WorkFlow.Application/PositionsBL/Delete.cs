using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.PositionsBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPositionsRepository _iPositionRepo;
            public Handler(IPositionsRepository iPositionRepo)
            {
                _iPositionRepo = iPositionRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iPositionRepo.DeletePosition(request.id);
                if (!result) return Result<Unit>.Failure("Failed to update Position");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
