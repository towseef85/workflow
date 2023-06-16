using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestControlConditionsBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostRequestFormControlConditionDto RequestFormControlConditions { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RequestFormControlConditions).SetValidator(new RequestFormControlConditionsValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IControlConditionRepository _iRequestFormControlConditionsRepo;
            public Handler(IControlConditionRepository iRequestFormControlConditionsRepo)
            {
                _iRequestFormControlConditionsRepo = iRequestFormControlConditionsRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iRequestFormControlConditionsRepo.AddControlCondition(request.RequestFormControlConditions, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Request Form Control Conditions");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
