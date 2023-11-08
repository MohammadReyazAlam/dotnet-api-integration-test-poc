using System.Reflection;

namespace Payments.Api.Integration.Http
{
    public class AuthorizationClient : IAuthorizationClient
    {
        private readonly ILogger<AuthorizationClient> logger;

        public AuthorizationClient(ILogger<AuthorizationClient> logger)
        {
            this.logger = logger;
        }
        
        public async Task<string> AuthorizePaymentAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            return await Task.Run(() => $"Authorization Successful - {authorizeRequest}");
        }

        
    }
}
