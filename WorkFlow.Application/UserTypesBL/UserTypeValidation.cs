using FluentValidation;
using WorkFlow.Application.Dtos.UsertypesDtos;

namespace WorkFlow.Application.UserTypesBL
{
    public class UserTypeValidation : AbstractValidator<PostUserTypeDto>
    {
        public UserTypeValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
        }
    }
}

