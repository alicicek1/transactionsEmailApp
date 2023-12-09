using BankingApplication.Transactions.Api.Request.Base;

namespace BankingApplication.Transactions.Api.Request;

public class SendTransactionsToEmailAddressRequestModel : RequestModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? UserEmailId { get; set; }
}