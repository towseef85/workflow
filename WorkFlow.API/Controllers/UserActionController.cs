using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.UserActionDto;
using WorkFlow.Application.UserActionsBL;

namespace WorkFlow.API.Controllers
{

    public class UserActionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostUserActionDto UserAction)
        {
            return HandleResult(await Mediator.Send(new Create.Command { UserAction = UserAction }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostUserActionDto UserAction)
        {
            UserAction.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { UserAction = UserAction }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { id = id }));
        }
    }
}
