using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.PositionsBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostPositionDto Position { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Position).SetValidator(new PositionValidation());
            }
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

                var result = await _iPositionRepo.UpdatePosition(request.Position);

                if (!result) return Result<Unit>.Failure("Failed to update Positions");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
