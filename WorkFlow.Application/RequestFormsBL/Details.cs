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
    public class Details
    {
        public class Query : IRequest<Result<GetRequestFormsDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetRequestFormsDto>>
        {
            private readonly IRequestFormsRepository _iRequestFormsRepo;
            public Handler(IRequestFormsRepository iRequestFormsRepo)
            {
                _iRequestFormsRepo = iRequestFormsRepo;
            }

            public async Task<Result<GetRequestFormsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestForms = await _iRequestFormsRepo.GetRequestFormsById(request.Id);

                return Result<GetRequestFormsDto>.Success(RequestForms);
            }
        }
    }
}
