using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UsertypesDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UserTypesBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostUserTypeDto UserType { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserType).SetValidator(new UserTypeValidation());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserTypeRepository _iUserTypeRepo;
            public Handler(IUserTypeRepository iUserTypeRepo)
            {
                _iUserTypeRepo = iUserTypeRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iUserTypeRepo.UpdateUserType(request.UserType);

                if (!result) return Result<Unit>.Failure("Failed to update UserTypes");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
