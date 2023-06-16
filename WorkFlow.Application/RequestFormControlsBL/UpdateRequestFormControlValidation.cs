using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;

namespace WorkFlow.Application.RequestFormControlsBL
{
    public class UpdateRequestFormControlValidation : AbstractValidator<UpdateRequestFormControlsDto>
    {
        public UpdateRequestFormControlValidation()
        {
            RuleFor(x => x.ControlName).NotEmpty();
            RuleFor(x => x.ControlType).NotEmpty();
        }
    }

  
}
