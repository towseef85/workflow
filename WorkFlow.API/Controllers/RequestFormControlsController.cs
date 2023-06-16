using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.RequestFormControlsDtos;
using WorkFlow.Application.RequestFormControlsBL;

namespace WorkFlow.API.Controllers
{

    public class RequestFormControlsController : BaseApiController
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
        public async Task<IActionResult> Create(PostRequestFormControlsDto RequestFormControls)
        {
            return HandleResult(await Mediator.Send(new Create.Command { RequestFormControls = RequestFormControls }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UpdateRequestFormControlsDto RequestFormControls)
        {
            RequestFormControls.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { RequestFormControls = RequestFormControls }));
        }


        [HttpGet("GetSelectControlData/{id}")]
        public async Task<IActionResult> GetSelectControlData(int id)
        {
            return HandleResult(await Mediator.Send(new GetSelectData.Query { Id = id}));
        }

        
    }
}
