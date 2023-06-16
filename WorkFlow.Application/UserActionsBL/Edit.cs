using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UserActionsBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostUserActionDto UserAction { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserAction).SetValidator(new UserActionValidation());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserActionsRepository _iUserActionRepo;
            public Handler(IUserActionsRepository iUserActionRepo)
            {
                _iUserActionRepo = iUserActionRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iUserActionRepo.UpdateUserAction(request.UserAction);

                if (!result) return Result<Unit>.Failure("Failed to update UserActions");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
