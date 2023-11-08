using Microsoft.AspNetCore.Mvc;
using Payments.Api.Business.Services;

namespace Payments.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> logger;
        private readonly IAuthorizationService authorizationService;
        private readonly ISettlementService settlementService;

        public PaymentsController(ILogger<PaymentsController> logger, 
            IAuthorizationService authorizationService, ISettlementService settlementService)
        {
            this.logger = logger;
            this.authorizationService = authorizationService;
            this.settlementService = settlementService;
        }

        [HttpPost()]
        [Route("authorize/v1")]
        public async Task<string> Authorize([FromBody] string authorizeRequest)
        {
            return await authorizationService.AuthorizePaymentAsync(authorizeRequest);
        }

        [HttpPost()]
        [Route("settle/v1")]
        public async Task<string> Settle([FromBody] string settlementRequest)
        {
            return await settlementService.SettlePaymentAsync(settlementRequest);
        }
    }
}