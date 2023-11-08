
namespace Payments.Api.Business.Services
{
    public interface IAuthorizationService
    {
        Task<string> AuthorizePaymentAsync(string authorizeRequest);
    }
}