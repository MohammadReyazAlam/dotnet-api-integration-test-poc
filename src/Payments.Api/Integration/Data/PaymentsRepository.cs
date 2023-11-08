using System.Reflection;

namespace Payments.Api.Integration.Data
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly ILogger<PaymentsRepository> logger;

        public PaymentsRepository(ILogger<PaymentsRepository> logger)
        {
            this.logger = logger;
        }
        public async Task<string> AuthorizeAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            return await Task.Run(() =>
            {
                string authorizeResponse = $"Successfully Settled: {authorizeRequest}";
                return authorizeResponse;
            });
        }

        public async Task<string> SettleAsync(string settlementRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{settlementRequest}']");
            return await Task.Run(() =>
            {
                string settlementResponse = $"Successfully Settled: {settlementRequest}";
                return settlementResponse;
            });

        }
    }
}
