using System.Globalization;
using BankingApplication.Core.Entities;
using CsvHelper;

namespace BankingApplication.Transactions.Database.Repository;

public class Database : IDatabase
{
    public List<TransactionEntity> GetTransactions(DateTime startDate, DateTime endDate, string? userEmailId)
    {
        var transactions = new List<TransactionEntity>();

        try
        {
            var path = System.Environment.CurrentDirectory + "/database.csv";
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var filteredData = csv.GetRecords<TransactionEntity>().ToList()
                .Where(t =>
                    t.DateOfTransaction <= endDate &&
                    t.DateOfTransaction >= startDate &&
                    (string.IsNullOrEmpty(userEmailId) || t.UserEmailId == userEmailId)
                )
                .ToList();
            transactions.AddRange(filteredData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
        }

        return transactions;
    }
}