using Microsoft.AspNetCore.Mvc;
using Payments.Api.Business.Services;

namespace Payments.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        public ILogger<PaymentsController> Logger { get; set; }
        public IAuthorizationService AuthorizationService { get; set; }
        public ISettlementService SettlementService { get; set; }

        //public PaymentsController(ILogger<PaymentsController> logger, 
        //    IAuthorizationService authorizationService, ISettlementService settlementService)
        //{
        //    this.logger = logger;
        //    this.authorizationService = authorizationService;
        //    this.settlementService = settlementService;
        //}

        [HttpPost()]
        [Route("authorize/v1")]
        public async Task<string> Authorize([FromBody] string authorizeRequest)
        {
            return await AuthorizationService.AuthorizePaymentAsync(authorizeRequest);
        }

        [HttpPost()]
        [Route("settle/v1")]
        public async Task<string> Settle([FromBody] string settlementRequest)
        {
            return await SettlementService.SettlePaymentAsync(settlementRequest);
        }
    }
}