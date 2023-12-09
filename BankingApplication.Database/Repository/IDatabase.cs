using BankingApplication.Core.Entities;

namespace BankingApplication.Transactions.Database.Repository;

public interface IDatabase
{
    List<TransactionEntity> GetTransactions(DateTime startDate, DateTime endDate, string? userEmailId);
}