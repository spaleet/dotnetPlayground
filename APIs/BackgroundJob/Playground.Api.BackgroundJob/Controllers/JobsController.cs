using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.BackgroundJob.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController : ControllerBase
{
    private readonly ILogger<JobsController> _logger;

    public JobsController(ILogger<JobsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok()
    }
}
