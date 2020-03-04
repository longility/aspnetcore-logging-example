using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> logger;

        public LogsController(ILogger<LogsController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Log()
        {
            logger.LogCritical("Hello world");
            return NoContent();
        }
    }
}
