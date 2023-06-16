using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestTypeDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestTypeBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetRequestTypeDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetRequestTypeDto>>>
        {
             private readonly IRequestTypesRepository _iRequestTypeRepo;
            public Handler(IRequestTypesRepository iRequestTypeRepo)
            {
                _iRequestTypeRepo = iRequestTypeRepo;
            }

            public async Task<Result<List<GetRequestTypeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var requesttypes = await _iRequestTypeRepo.GetAllRequestTypes();
                return Result<List<GetRequestTypeDto>>.Success(requesttypes);
            }
        }
    }
}
