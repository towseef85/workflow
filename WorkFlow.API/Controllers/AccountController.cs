using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.IdentityDtos;
using WorkFlow.Application.IdentityBL;

namespace WorkFlow.API.Controllers
{

    public class AccountController : BaseApiController
    {
        [HttpGet("GetRoleList")]
        public async Task<IActionResult> GetRoleList()
        {
            return HandleResult(await Mediator.Send(new RoleList.Query()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            return HandleResult(await Mediator.Send(new UserDetails.Query { Id = id }));
        }
        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            return HandleResult(await Mediator.Send(new UserList.Query()));
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(PostUserDto User)
        {
            return HandleResult(await Mediator.Send(new CreateUser.Command {  User = User }));
        }

        [HttpPut("EditUser/{id}")]
        public async Task<IActionResult> EditUser(PostUserDto user)
        {
            return HandleResult(await Mediator.Send(new EditUser.Command { User = user }));
        }

    }
}
