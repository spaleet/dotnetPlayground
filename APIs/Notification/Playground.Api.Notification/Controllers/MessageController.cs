using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Api.Events;
using Playground.Api.Models;

namespace Playground.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SayHello([FromBody] SayHelloDto model)
    {
        await _mediator.Publish(new SayHelloEvent(model.Message));
        return Ok();
    }
}
