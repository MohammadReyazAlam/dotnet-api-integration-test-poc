
namespace Payments.Api.Business.Services
{
    public interface ISettlementService
    {
        Task<string> SettlePaymentAsync(string settlementRequest);
    }
}