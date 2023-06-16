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
    public class Details
    {
        public class Query : IRequest<Result<GetUserActionDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetUserActionDto>>
        {
            private readonly IUserActionsRepository _iUserActionRepo;
            public Handler(IUserActionsRepository iUserActionRepo)
            {
                _iUserActionRepo = iUserActionRepo;
            }

            public async Task<Result<GetUserActionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var UserAction = await _iUserActionRepo.GetUserActionById(request.Id);

                return Result<GetUserActionDto>.Success(UserAction);
            }
        }
    }
}
