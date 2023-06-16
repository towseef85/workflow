using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestControlConditionsBL
{
    public class GetConditionByFormId
    {
        public class Query : IRequest<Result<List<GetRequestFormControlConditionsDto>>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GetRequestFormControlConditionsDto>>>
        {
            private readonly IControlConditionRepository _iRequestFormControlConditionsRepo;
            public Handler(IControlConditionRepository iRequestFormControlConditionsRepo)
            {
                _iRequestFormControlConditionsRepo = iRequestFormControlConditionsRepo;
            }

            public async Task<Result<List<GetRequestFormControlConditionsDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestFormControls = await _iRequestFormControlConditionsRepo.GetControlConditionByFormId(request.Id);

                return Result<List<GetRequestFormControlConditionsDto>>.Success(RequestFormControls);
            }
        }
    }
}
