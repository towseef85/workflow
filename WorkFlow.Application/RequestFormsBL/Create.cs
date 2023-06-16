using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormsBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostRequestFormsDto RequestForms { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RequestForms).SetValidator(new RequestFormsValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IRequestFormsRepository _iRequestFormsRepo;
            public Handler(IRequestFormsRepository iRequestFormsRepo)
            {
                _iRequestFormsRepo = iRequestFormsRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iRequestFormsRepo.AddRequestForms(request.RequestForms, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Request Forms");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
