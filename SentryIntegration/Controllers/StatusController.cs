using Microsoft.AspNetCore.Mvc;
using SentryIntegration.Models;

namespace SentryIntegration.Controllers 
{
    [ApiController]
    public class StatusController : ControllerBase
    {

        [HttpGet("/api/v1/status")]
        public StatusResponse Get()
        {
            return new StatusResponse { Status = "OK", Version = "0.1.0" };
        }
    }
}