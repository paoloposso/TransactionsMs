using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Domain.UseCases;

namespace Transactions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;
        private readonly AccountTransactionUseCases _accountTransactionsService;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

    }
}
