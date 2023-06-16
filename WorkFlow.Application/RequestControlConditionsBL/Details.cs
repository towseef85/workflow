using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestControlConditionsBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetRequestFormControlConditionsDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetRequestFormControlConditionsDto>>
        {
            private readonly IControlConditionRepository _iRequestFormControlConditionsRepo;
            public Handler(IControlConditionRepository iRequestFormControlConditionsRepo)
            {
                _iRequestFormControlConditionsRepo = iRequestFormControlConditionsRepo;
            }

            public async Task<Result<GetRequestFormControlConditionsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestFormControls = await _iRequestFormControlConditionsRepo.GetControlConditionById(request.Id);

                return Result<GetRequestFormControlConditionsDto>.Success(RequestFormControls);
            }
        }
    }
}
