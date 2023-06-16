using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.RequestFormControlConditionsDtos;
using WorkFlow.Application.RequestControlConditionsBL;

namespace WorkFlow.API.Controllers
{

    public class ControlConditionsController : BaseApiController
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
        [HttpGet("GetConditionByFormID/{id}")]
        public async Task<IActionResult> GetConditionByFormID(int id)
        {
            return HandleResult(await Mediator.Send(new GetConditionByFormId.Query { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostRequestFormControlConditionDto Conditions)
        {
            return HandleResult(await Mediator.Send(new Create.Command { RequestFormControlConditions = Conditions }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostRequestFormControlConditionDto Conditions)
        {
            Conditions.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { RequestFormControlConditions = Conditions }));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return HandleResult(await Mediator.Send(new Delete.Command { id = id }));
        //}
    }
}
