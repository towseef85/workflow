﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlow.Application.Core;

namespace WorkFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

#pragma warning disable CS8603 // Possible null reference return.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8603 // Possible null reference return.

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null)
                return NotFound();
            return BadRequest(result.Error);
        }
    }
}
