using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.UserConditionDtos;
using WorkFlow.Application.UsersConditionBL;

namespace WorkFlow.API.Controllers
{

    public class UsersConditionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostUserConditionDto Conditions)
        {
            return HandleResult(await Mediator.Send(new Create.Command { UsersCondition = Conditions }));
        }
    }
}
