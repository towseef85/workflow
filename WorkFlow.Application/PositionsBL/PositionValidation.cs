using FluentValidation;
using WorkFlow.Application.Dtos.PositionDtos;

namespace WorkFlow.Application.PositionsBL
{
    public class PositionValidation : AbstractValidator<PostPositionDto>
    {
        public PositionValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.ArbName).NotEmpty();
        }
    }
}

