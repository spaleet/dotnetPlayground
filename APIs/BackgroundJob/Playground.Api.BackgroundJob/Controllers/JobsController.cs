using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.BackgroundJob.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JobsController : ControllerBase
{
    private readonly ILogger<JobsController> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public JobsController(ILogger<JobsController> logger, IBackgroundJobClient backgroundJobClient)
    {
        _logger = logger; 
        _backgroundJobClient = backgroundJobClient;
    }

    [HttpPost("fire-and-forget")]
    public IActionResult FireAndForget([FromRoute] string message)
    {
        string jobId = _backgroundJobClient.Enqueue(() => StartSomeTask(message));

        return Ok($"Job Id {jobId} Completed !");
    }


    private Task StartSomeTask(string message)
    {
        // Some Task
        _logger.LogInformation("Message : {message}", message);

        return Task.CompletedTask;
    }
}
