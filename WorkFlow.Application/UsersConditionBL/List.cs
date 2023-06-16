using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UserConditionDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UsersConditionBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetUsersConditionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetUsersConditionDto>>>
        {
            private readonly IUsersConditionRepository _iUsersConditionRepo;
            public Handler(IUsersConditionRepository iUsersConditionRepo)
            {
                _iUsersConditionRepo = iUsersConditionRepo;
            }

            public async Task<Result<List<GetUsersConditionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var UserConditions = await _iUsersConditionRepo.GetAllUsersCondtions();
                return Result<List<GetUsersConditionDto>>.Success(UserConditions);
            }
        }
    }
}
