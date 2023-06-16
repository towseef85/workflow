using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.PositionDtos;
using WorkFlow.Application.PositionsBL;

namespace WorkFlow.API.Controllers
{

    public class PositionController : BaseApiController
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
        public async Task<IActionResult> Create(PostPositionDto Position)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Position = Position }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostPositionDto Position)
        {
            Position.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Position = Position }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { id = id }));
        }
    }
}
