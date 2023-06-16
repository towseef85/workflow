using FluentValidation;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;

namespace WorkFlow.Application.RequestControlConditionsBL
{
    public class RequestFormControlConditionsValidation : AbstractValidator<PostRequestFormControlConditionDto>
    {
        public RequestFormControlConditionsValidation()
        {
            RuleFor(x => x.EngDescription).NotEmpty();
            RuleFor(x => x.FormId).NotEmpty();

        }
    }
}
