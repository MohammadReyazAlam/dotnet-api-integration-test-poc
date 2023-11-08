using Payments.Api.Integration.Data;
using Payments.Api.Integration.Http;
using System.Reflection;

namespace Payments.Api.Business.Services
{
    public class SettlementService : ISettlementService
    {
        public ILogger<SettlementService> Logger { get; set; }
        public IPaymentsRepository PaymentsRepository { get; set; }
        public ISettlementClient SettlementClient { get; set; }

        //public SettlementService(ILogger<SettlementService> logger,
        //    IPaymentsRepository paymentsRepository, ISettlementClient settlementClient)
        //{
        //    this.logger = logger;
        //    this.paymentsRepository = paymentsRepository;
        //    this.settlementClient = settlementClient;
        //}
        
        public async Task<string> SettlePaymentAsync(string settlementRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            Logger.LogInformation($"Executing {currentMethod} with request ['{settlementRequest}']");
            var settlementResponse = await SettlementClient.SettlePaymentAsync(settlementRequest);
            return await PaymentsRepository.SettleAsync(settlementResponse);
        }
    }
}
