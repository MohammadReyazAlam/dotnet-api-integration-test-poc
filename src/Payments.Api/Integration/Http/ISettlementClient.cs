namespace Payments.Api.Integration.Http
{
    public interface ISettlementClient
    {
        Task<string> SettlePaymentAsync(string settlementRequest);
    }
}
    