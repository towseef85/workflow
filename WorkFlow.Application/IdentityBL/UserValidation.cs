using FluentValidation;
using WorkFlow.Application.Dtos.IdentityDtos;

namespace WorkFlow.Application.IdentityBL
{
    public class UserValidation : AbstractValidator<PostUserDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.UserMode).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserTypeId).NotEmpty();
        }
    }
}
