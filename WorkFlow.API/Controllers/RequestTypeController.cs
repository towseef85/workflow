using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.RequestTypeDtos;
using WorkFlow.Application.RequestTypeBL;

namespace WorkFlow.API.Controllers
{

    public class RequestTypeController : BaseApiController
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
        public async Task<IActionResult> Create(PostRequestTypeDto RequestType)
        {
            return HandleResult(await Mediator.Send(new Create.Command { RequestType = RequestType }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostRequestTypeDto RequestType)
        {
            RequestType.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { RequestType = RequestType }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send( new Delete.Command { id = id }));
        }
    }
}
