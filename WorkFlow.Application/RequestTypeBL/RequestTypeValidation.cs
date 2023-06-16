using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.RequestTypeDtos;

namespace WorkFlow.Application.RequestTypeBL
{
    public class RequestTypeValidation : AbstractValidator<PostRequestTypeDto>
    {
        public RequestTypeValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
        }
    }
}
