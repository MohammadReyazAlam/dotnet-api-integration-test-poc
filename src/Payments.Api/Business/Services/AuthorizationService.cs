using Payments.Api.Integration.Data;
using Payments.Api.Integration.Http;
using System.Reflection;

namespace Payments.Api.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public ILogger<AuthorizationService> Logger { get; set; }
        public IPaymentsRepository PaymentsRepository { get; set; }
        public IAuthorizationClient AuthorizationClient { get; set; }

        //public AuthorizationService(ILogger<AuthorizationService> logger,
        //    IPaymentsRepository paymentsRepository, IAuthorizationClient authorizationClient)
        //{
        //    this.Logger = logger;
        //    this.paymentsRepository = paymentsRepository;
        //    this.authorizationClient = authorizationClient;
        //}
        public async Task<string> AuthorizePaymentAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            Logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            var authorizeResponse = await AuthorizationClient.AuthorizePaymentAsync(authorizeRequest);
            
            return await PaymentsRepository.AuthorizeAsync(authorizeResponse);
        }
    }
}
