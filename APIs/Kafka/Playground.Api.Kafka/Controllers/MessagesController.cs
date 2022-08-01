using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.Kafka.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly ILogger<MessagesController> _logger;

    public MessagesController(ILogger<MessagesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
