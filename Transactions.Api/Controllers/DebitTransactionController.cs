using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Api.Dto;
using Transactions.Domain.Services;

namespace Transactions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitTransactionController : ControllerBase
    {
        private readonly ILogger<DebitTransactionController> _logger;
        private readonly AccountTransactionService _accountTransactionsService;

        public DebitTransactionController(ILogger<DebitTransactionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<DebitResponse>> Post([FromBody]DebitRequest debitRequest)
        {
            try
            {
                var accountTransaction = await _accountTransactionsService.Save(debitRequest.Value, debitRequest.AccountId);

                return Ok(new DebitResponse { Successful = true });
            }
            catch (Exception ex)
            {
                var errors = new List<string>();
                errors.Add($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");

                return StatusCode(500, new DebitResponse {
                    ErrorList = errors,
                    Successful = false,
                });
            }
        }
    }
}
