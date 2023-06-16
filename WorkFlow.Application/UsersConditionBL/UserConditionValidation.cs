using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Application.Dtos.UserConditionDtos;

namespace WorkFlow.Application.UsersConditionBL
{
    public class UserConditionValidation : AbstractValidator<PostUserConditionDto>
    {
        public UserConditionValidation()
        {
            RuleFor(x => x.UserConditions.Select(x=>x.RequestConditionId)).NotEmpty();
            RuleFor(x => x.UserConditions.Select(x => x.PriorityLevel)).NotEmpty();
        }
    }
}
