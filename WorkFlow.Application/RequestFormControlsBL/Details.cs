using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetRequestFormControlsDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetRequestFormControlsDto>>
        {
            private readonly IRequestFormControlsRepository _iRequestFormControlsRepo;
            public Handler(IRequestFormControlsRepository iRequestFormControlsRepo)
            {
                _iRequestFormControlsRepo = iRequestFormControlsRepo;
            }

            public async Task<Result<GetRequestFormControlsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestFormControls = await _iRequestFormControlsRepo.GetRequestFormControlsById(request.Id);

                return Result<GetRequestFormControlsDto>.Success(RequestFormControls);
            }
        }
    }
}
