using MediatR;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.IdentityBL
{
    public class UserList
    {
        public class Query : IRequest<Result<List<GetUserDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GetUserDto>>>
        {
            private readonly IIdentityRepository _iIdentityRepo;
            public Handler(IIdentityRepository iIdentityRepo)
            {
                _iIdentityRepo = iIdentityRepo;
            }

            public async Task<Result<List<GetUserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _iIdentityRepo.GetAllUsers();
                return Result<List<GetUserDto>>.Success(data);
            }
        }
    }
}
