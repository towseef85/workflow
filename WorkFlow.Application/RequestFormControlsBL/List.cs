using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetRequestFormControlsDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetRequestFormControlsDto>>>
        {
            private readonly IRequestFormControlsRepository _iRequestFormControlsRepo;
            public Handler(IRequestFormControlsRepository iRequestFormControlsRepo)
            {
                _iRequestFormControlsRepo = iRequestFormControlsRepo;
            }

            public async Task<Result<List<GetRequestFormControlsDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestFormControls = await _iRequestFormControlsRepo.GetAllRequestFormControls();
                return Result<List<GetRequestFormControlsDto>>.Success(RequestFormControls);
            }
        }
    }
}
