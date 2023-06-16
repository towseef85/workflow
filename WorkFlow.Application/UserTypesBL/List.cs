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
    public class List
    {
        public class Query : IRequest<Result<List<GetUserTypeDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetUserTypeDto>>>
        {
            private readonly IUserTypeRepository _iUserTypeRepo;
            public Handler(IUserTypeRepository iUserTypeRepo)
            {
                _iUserTypeRepo = iUserTypeRepo;
            }

            public async Task<Result<List<GetUserTypeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var UserTypes = await _iUserTypeRepo.GetAllUserTypes();
                return Result<List<GetUserTypeDto>>.Success(UserTypes);
            }
        }
    }
}
