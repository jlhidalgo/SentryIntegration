using Microsoft.AspNetCore.Mvc;
using SentryIntegration.Interfaces;
using SentryIntegration.Models;
using System;

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
            
            return new StatusResponse { Status = "OK", Version = "0.1.0" };
        }
        
        [HttpGet("/api/v1/notimplementedpost")]
        public StatusResponse NotImplemented()
        {
            var response = new StatusResponse();
            try
            {
                _logger.LogError("Generating error for testing sentry");
                throw new NotImplementedException("This method has not been implemented yet");
            }
            catch (NotImplementedException)
            {
                throw;
            }
            
            return response;

        }
    }
}