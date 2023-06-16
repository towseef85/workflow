using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Dtos.RequestFormsDtos;
using WorkFlow.Application.RequestFormsBL;

namespace WorkFlow.API.Controllers
{

    public class RequestFormsController : BaseApiController
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
        public async Task<IActionResult> Create(PostRequestFormsDto RequestForm)
        {
            return HandleResult(await Mediator.Send(new Create.Command { RequestForms = RequestForm }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, PostRequestFormsDto RequestForm)
        {
            RequestForm.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { RequestForms = RequestForm }));
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return HandleResult(await Mediator.Send(new Delete.Command { id = id }));
        //}
    }
}
