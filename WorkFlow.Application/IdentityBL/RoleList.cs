using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.IdentityBL
{
    public class RoleList
    {
        public class Query : IRequest<Result<List<GetRoleDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetRoleDto>>>
        {
            private readonly IIdentityRepository _iIdentityRepo;
            public Handler(IIdentityRepository iIdentityRepo)
            {
                _iIdentityRepo = iIdentityRepo;
            }

            public async Task<Result<List<GetRoleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Positions = await _iIdentityRepo.GetAllRoles();
                return Result<List<GetRoleDto>>.Success(Positions);
            }
        }
    }
}
