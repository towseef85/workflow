using FluentValidation;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.Dtos.UsertypesDtos;

namespace WorkFlow.Application.UserActionsBL
{
    public class UserActionValidation : AbstractValidator<PostUserActionDto>
    {
        public UserActionValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
        }
    }
}

