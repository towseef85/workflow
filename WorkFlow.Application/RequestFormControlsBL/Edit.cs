using FluentValidation;
using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateRequestFormControlsDto RequestFormControls { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RequestFormControls).SetValidator(new UpdateRequestFormControlValidation());
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

                var result = await _iRequestFormControlsRepo.UpdateRequestFormControls(request.RequestFormControls);

                if (!result) return Result<Unit>.Failure("Failed to update RequestFormControlss");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
