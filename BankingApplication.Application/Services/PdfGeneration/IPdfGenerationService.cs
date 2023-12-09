using BankingApplication.Core.Entities;

namespace BankingApplication.Application.Services.PdfGeneration;

public interface IPdfGenerationService
{
    byte[] GeneratePdf(List<TransactionEntity> transactions);
}