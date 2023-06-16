using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.RequestFormsDtos;

namespace WorkFlow.Application.RequestFormsBL
{
 
    public class RequestFormsValidation : AbstractValidator<PostRequestFormsDto>
    {
        public RequestFormsValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
            RuleFor(x=>x.RequestTypeId).NotEmpty();
        }
    }
}
