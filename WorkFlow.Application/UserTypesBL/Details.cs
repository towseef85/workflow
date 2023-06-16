using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UsertypesDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UserTypesBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetUserTypeDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetUserTypeDto>>
        {
            private readonly IUserTypeRepository _iUserTypeRepo;
            public Handler(IUserTypeRepository iUserTypeRepo)
            {
                _iUserTypeRepo = iUserTypeRepo;
            }

            public async Task<Result<GetUserTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var UserType = await _iUserTypeRepo.GetUserTypeById(request.Id);

                return Result<GetUserTypeDto>.Success(UserType);
            }
        }
    }
}
