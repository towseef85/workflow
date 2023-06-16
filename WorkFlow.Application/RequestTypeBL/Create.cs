using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestTypeDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestTypeBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostRequestTypeDto RequestType { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RequestType).SetValidator(new RequestTypeValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IRequestTypesRepository _iRequestTypeRepo;
            public Handler(IRequestTypesRepository iRequestTypeRepo)
            {
                _iRequestTypeRepo = iRequestTypeRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iRequestTypeRepo.AddRequestType(request.RequestType, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Categories");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
