using System.Reflection;

namespace Payments.Api.Integration.Http
{
    public class AuthorizationClient : IAuthorizationClient
    {
        public ILogger<AuthorizationClient> Logger { get; set; }

        //public AuthorizationClient(ILogger<AuthorizationClient> logger)
        //{
        //    this.logger = logger;
        //}
        
        public async Task<string> AuthorizePaymentAsync(string authorizeRequest)
        {
            var currentMethod = $"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}";
            Logger.LogInformation($"Executing {currentMethod} with request ['{authorizeRequest}']");
            return await Task.Run(() => $"Authorization Successful - {authorizeRequest}");
        }

        
    }
}
