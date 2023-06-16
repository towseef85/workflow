using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UserConditionDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UsersConditionBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostUserConditionDto UsersCondition { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UsersCondition).SetValidator(new UserConditionValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUsersConditionRepository _iUsersConditionRepo;
            public Handler(IUsersConditionRepository iUsersConditionRepo)
            {
                _iUsersConditionRepo = iUsersConditionRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iUsersConditionRepo.AddUsersCondition(request.UsersCondition, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add UsersCondition");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
