namespace Payments.Api.Integration.Data
{
    public interface IPaymentsRepository
    {
        Task<string> AuthorizeAsync(string authorizeRequest);
        Task<string> SettleAsync(string settlementRequest);
    }
}