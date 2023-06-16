using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.IdentityBL
{
    public class CreateRole 
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostRoleDto RoleDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RoleDto.EngName).NotEmpty().NotNull();
                RuleFor(x => x.RoleDto.Role).NotEmpty().NotNull();
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
                var result = await _iIdentityRepo.AddUserRole(request.RoleDto, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Role");
                return Result<Unit>.Success(Unit.Value);
            }
        }


        }
}
