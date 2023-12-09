using BankingApplication.Application.Models;
using BankingApplication.Application.Services.Email;
using BankingApplication.Application.Services.PdfGeneration;
using BankingApplication.Transactions.Database.Repository;

namespace BankingApplication.Application.Services.Transaction;

public class TransactionsService : ITransactionsService
{
    private readonly IDatabase _database;
    private readonly IPdfGenerationService _pdfGenerationService;
    private readonly IEmailService _emailService;

    public TransactionsService(IPdfGenerationService pdfGenerationService, IEmailService emailService,
        IDatabase database)
    {
        _pdfGenerationService = pdfGenerationService;
        _emailService = emailService;
        _database = database;
    }

    public string SendTransactionsToEmailAddress(
        SendTransactionsToEmailAddressModel sendTransactionsToEmailAddressModel)
    {
        var transactionEntities = _database.GetTransactions(
            sendTransactionsToEmailAddressModel.StartDate,
            sendTransactionsToEmailAddressModel.EndDate, sendTransactionsToEmailAddressModel.UserEmailId);

        if (!transactionEntities.Any())
        {
            return "There is no transaction to send.";
        }

        var arr = _pdfGenerationService.GeneratePdf(transactionEntities);

        _emailService.SendEmail("", arr, "");

        return "Transactions send your e-mail address.Check your e-mail.";
    }
}