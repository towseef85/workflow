using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.UsertypesDtos;
using WorkFlow.Application.UserTypesBL;

namespace WorkFlow.API.Controllers
{

    public class UserTypeController : BaseApiController
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
        public async Task<IActionResult> Create(PostUserTypeDto UserType)
        {
            return HandleResult(await Mediator.Send(new Create.Command { UserType = UserType }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostUserTypeDto UserType)
        {
            UserType.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { UserType = UserType }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { id = id }));
        }
    }
}
