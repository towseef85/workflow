using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.IdentityBL
{
    public class CreateUser
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostUserDto User { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.User).SetValidator(new UserValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IIdentityRepository _iIdentityRepo;
            public Handler(IIdentityRepository iIdentityRepo)
            {
                _iIdentityRepo = iIdentityRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iIdentityRepo.AddUser(request.User, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add User");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
