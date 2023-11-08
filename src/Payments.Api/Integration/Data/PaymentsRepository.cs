using System.Reflection;

namespace Payments.Api.Integration.Data
{
    public class PaymentsRepository : IPaymentsRepository
    {
        public ILogger<PaymentsRepository> Logger { get; set; }

        //public PaymentsRepository(ILogger<PaymentsRepository> logger)
        //{
        //    this.logger = logger;
        //}
        public async Task<string> AuthorizeAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            Logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            return await Task.Run(() =>
            {
                string authorizeResponse = $"Successfully Settled: {authorizeRequest}";
                return authorizeResponse;
            });
        }

        public async Task<string> SettleAsync(string settlementRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            Logger.LogInformation($"Executing {currentMethod} with request ['{settlementRequest}']");
            return await Task.Run(() =>
            {
                string settlementResponse = $"Successfully Settled: {settlementRequest}";
                return settlementResponse;
            });

        }
    }
}
