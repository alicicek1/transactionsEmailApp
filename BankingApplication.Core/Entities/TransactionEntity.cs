using CsvHelper.Configuration.Attributes;

namespace BankingApplication.Core.Entities;

public class TransactionEntity : Entity
{
    [Index(0)] public string UserEmailId { get; set; }
    [Index(1)] public DateTime DateOfTransaction { get; set; }
    [Index(2)] public decimal Amount { get; set; }
}