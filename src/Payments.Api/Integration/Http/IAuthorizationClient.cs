namespace Payments.Api.Integration.Http
{
    public interface IAuthorizationClient
    {
        Task<string> AuthorizePaymentAsync(string authorizeRequest);
    }
}
