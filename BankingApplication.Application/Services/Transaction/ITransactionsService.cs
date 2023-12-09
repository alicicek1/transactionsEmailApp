using BankingApplication.Application.Models;

namespace BankingApplication.Application.Services.Transaction;

public interface ITransactionsService
{
    string SendTransactionsToEmailAddress(SendTransactionsToEmailAddressModel sendTransactionsToEmailAddressModel);
}