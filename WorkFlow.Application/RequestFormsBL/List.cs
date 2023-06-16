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
    public class List
    {
        public class Query : IRequest<Result<List<GetRequestFormsDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetRequestFormsDto>>>
        {
            private readonly IRequestFormsRepository _iRequestFormsRepo;
            public Handler(IRequestFormsRepository iRequestFormsRepo)
            {
                _iRequestFormsRepo = iRequestFormsRepo;
            }

            public async Task<Result<List<GetRequestFormsDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestForms = await _iRequestFormsRepo.GetAllRequestForms();
                return Result<List<GetRequestFormsDto>>.Success(RequestForms);
            }
        }
    }
}
