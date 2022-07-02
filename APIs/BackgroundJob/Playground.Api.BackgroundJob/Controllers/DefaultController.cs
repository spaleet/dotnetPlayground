using Microsoft.AspNetCore.Mvc;

namespace Playground.Api.BackgroundJob.Controllers;

public class DefaultController : ControllerBase
{
    [Route(""), HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public RedirectResult RedirectToSwaggerUi()
    {
        return Redirect("/swagger/");
    }
}
