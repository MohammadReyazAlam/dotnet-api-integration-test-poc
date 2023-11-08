using Payments.Api.Integration.Data;
using Payments.Api.Integration.Http;
using System.Reflection;

namespace Payments.Api.Business.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly ILogger<SettlementService> logger;
        private readonly IPaymentsRepository paymentsRepository;
        private readonly ISettlementClient settlementClient;

        public SettlementService(ILogger<SettlementService> logger,
            IPaymentsRepository paymentsRepository, ISettlementClient settlementClient)
        {
            this.logger = logger;
            this.paymentsRepository = paymentsRepository;
            this.settlementClient = settlementClient;
        }
        
        public async Task<string> SettlePaymentAsync(string settlementRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{settlementRequest}']");
            var settlementResponse = await settlementClient.SettlePaymentAsync(settlementRequest);
            return await paymentsRepository.SettleAsync(settlementResponse);
        }
    }
}
