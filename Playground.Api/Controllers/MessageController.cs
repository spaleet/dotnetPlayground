using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Api.Events;
using Playground.Api.Models;

namespace Playground.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMediator _mediator;

    public MessageController(ILogger<MessageController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SayHello([FromBody] SayHelloDto model)
    {
        await _mediator.Publish(new SayHelloEvent(model.Message));

        return Ok();
    }
}
