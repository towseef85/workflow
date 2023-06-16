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
    public class Details
    {
        public class Query : IRequest<Result<GetRequestTypeDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetRequestTypeDto>>
        {
            private readonly IRequestTypesRepository _iRequestTypeRepo;
            public Handler(IRequestTypesRepository iRequestTypeRepo)
            {
                _iRequestTypeRepo = iRequestTypeRepo;
            }

            public async Task<Result<GetRequestTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestType = await _iRequestTypeRepo.GetRequestTypeById(request.Id);

                return Result<GetRequestTypeDto>.Success(RequestType);
            }
        }
    }
}
