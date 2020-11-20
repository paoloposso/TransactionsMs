using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Transactions.Domain.UseCases;

namespace Transactions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger, IConfiguration configuration)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInformation("Info");
            _logger.LogWarning("Warning");
            _logger.LogError("Error");

            _logger.LogInformation($"MongoDb Uri: {Environment.GetEnvironmentVariable("MONGODB_URI")}");

            return Ok("Ok");
        }
    }
}
