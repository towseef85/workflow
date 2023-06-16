using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UserActionsBL
{
    public class List
    {
        public class Query : IRequest<Result<List<GetUserActionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetUserActionDto>>>
        {
            private readonly IUserActionsRepository _iUserActionRepo;
            public Handler(IUserActionsRepository iUserActionRepo)
            {
                _iUserActionRepo = iUserActionRepo;
            }

            public async Task<Result<List<GetUserActionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var UserActions = await _iUserActionRepo.GetAllUserActions();
                return Result<List<GetUserActionDto>>.Success(UserActions);
            }
        }
    }
}
