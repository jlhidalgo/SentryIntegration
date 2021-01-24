using Microsoft.AspNetCore.Mvc;
using SentryIntegration.Interfaces;
using SentryIntegration.Models;

namespace SentryIntegration.Controllers 
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public StatusController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpGet("/api/v1/status")]
        public StatusResponse Get()
        {
            _logger.LogInformation("Sending status back");
            return new StatusResponse { Status = "OK", Version = "0.1.0" };
        }
    }
}