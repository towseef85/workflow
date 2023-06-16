using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostRequestFormControlsDto RequestFormControls { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RequestFormControls).SetValidator(new RequestFormControlsValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IRequestFormControlsRepository _iRequestFormControlsRepo;
            public Handler(IRequestFormControlsRepository iRequestFormControlsRepo)
            {
                _iRequestFormControlsRepo = iRequestFormControlsRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iRequestFormControlsRepo.AddRequestFormControls(request.RequestFormControls, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Request Form Controls");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
