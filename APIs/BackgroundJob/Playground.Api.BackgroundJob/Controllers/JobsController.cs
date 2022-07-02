using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.BackgroundJob.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    #region ctor

    private readonly ILogger<JobsController> _logger;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;

    public JobsController(ILogger<JobsController> logger, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
    {
        _logger = logger;
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
    }

    #endregion

    #region Fire-And-Forget

    [HttpPost("fire-and-forget")]
    public IActionResult FireAndForget([FromQuery] string message)
    {
        string jobId = _backgroundJobClient.Enqueue(() => StartSomeTask(message));

        return Ok($"Job Id {jobId} Completed !");
    }

    #endregion

    #region Delayed

    [HttpPost("delayed")]
    public IActionResult Delayed([FromQuery] string message, [FromQuery] int seconds)
    {
        string jobId = _backgroundJobClient.Schedule(() => StartSomeTask(message),
                                                     TimeSpan.FromSeconds(seconds));

        return Ok($"Job Id {jobId} Will Be Executed in {seconds} Seconds !");
    }

    [HttpPost("delayed/date")]
    public IActionResult DelayedDate([FromQuery] string message)
    {
        var date = new DateTimeOffset(DateTime.Now.AddDays(1));

        string jobId = _backgroundJobClient.Schedule(() => StartSomeTask(message), date);

        return Ok($"Job Id {jobId} Will Be Executed in {date.Date:mm/dd/yyyy} !");
    }

    #endregion

    #region Recurring 

    [HttpPost("recurring")]
    public IActionResult Recurring()
    {
        _recurringJobManager.AddOrUpdate("recurring_test", () => RecurringTask(), Cron.Daily);

        return Ok();
    }

    #endregion

    #region Tasks

    [NonAction]
    public Task StartSomeTask(string message)
    {
        // Some Task
        _logger.LogInformation("Message : {message}", message);

        return Task.CompletedTask;
    }

    [NonAction]
    public Task RecurringTask()
    {
        // Recurring Task
        _logger.LogInformation("Recurring Task");

        return Task.CompletedTask;
    }

    #endregion
}
