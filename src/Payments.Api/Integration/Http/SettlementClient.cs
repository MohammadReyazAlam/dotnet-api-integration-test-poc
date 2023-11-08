using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Payments.Api.Integration.Http
{
    public class SettlementClient : ISettlementClient
    {
        private readonly ILogger<SettlementClient> logger;

        public SettlementClient(ILogger<SettlementClient> logger)
        {
            this.logger = logger;
        }
        public Task<string> SettlePaymentAsync(string settlementRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{settlementRequest}']");
            return Task.FromResult($"SettlementClient.Settle({settlementRequest})");
        }
    }
}
