using Payments.Api.Integration.Data;
using Payments.Api.Integration.Http;
using System.Reflection;

namespace Payments.Api.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ILogger<AuthorizationService> logger;
        private readonly IPaymentsRepository paymentsRepository;
        private readonly IAuthorizationClient authorizationClient;

        public AuthorizationService(ILogger<AuthorizationService> logger,
            IPaymentsRepository paymentsRepository, IAuthorizationClient authorizationClient)
        {
            this.logger = logger;
            this.paymentsRepository = paymentsRepository;
            this.authorizationClient = authorizationClient;
        }
        public async Task<string> AuthorizePaymentAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            var authorizeResponse = await authorizationClient.AuthorizePaymentAsync(authorizeRequest);
            
            return await paymentsRepository.AuthorizeAsync(authorizeResponse);
        }
    }
}
