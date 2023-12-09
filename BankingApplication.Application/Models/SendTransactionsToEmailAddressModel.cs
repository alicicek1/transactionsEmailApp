namespace BankingApplication.Application.Models;

public class SendTransactionsToEmailAddressModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? UserEmailId { get; set; }
}