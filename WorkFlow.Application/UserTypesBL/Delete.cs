using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.UserTypesBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public int id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserTypeRepository _iUserTypeRepo;
            public Handler(IUserTypeRepository iUserTypeRepo)
            {
                _iUserTypeRepo = iUserTypeRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iUserTypeRepo.DeleteUserType(request.id);
                if (!result) return Result<Unit>.Failure("Failed to update UserType");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
