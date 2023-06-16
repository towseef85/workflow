using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Core;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.Interfaces;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class GetSelectData
    {
        public class Query : IRequest<Result<List<SelectData>>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<SelectData>>>
        {
            private readonly IRequestFormControlsRepository _iRequestFormControlsRepo;
            public Handler(IRequestFormControlsRepository iRequestFormControlsRepo)
            {
                _iRequestFormControlsRepo = iRequestFormControlsRepo;
            }

            public async Task<Result<List<SelectData>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var RequestFormControls = await _iRequestFormControlsRepo.GetRequestFormControlsById(request.Id);
                if(RequestFormControls.DataSourceType == "internal")
                {
                   var getData = await _iRequestFormControlsRepo.GetSelectDataForControl(request.Id);
                    return Result<List<SelectData>>.Success(getData);
                }

                return new Result<List<SelectData>>();
                
            }
        }
    }
}
