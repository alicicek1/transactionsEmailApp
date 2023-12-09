using BankingApplication.Core.Entities;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace BankingApplication.Application.Services.PdfGeneration;

public class PdfGenerationService : IPdfGenerationService
{
    public byte[] GeneratePdf(List<TransactionEntity> transactions)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            using (var writer = new PdfWriter(stream))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    var table = new Table(3);
                    table.AddHeaderCell("User Email");
                    table.AddHeaderCell("Date of Transaction");
                    table.AddHeaderCell("Amount");

                    foreach (var transaction in transactions)
                    {
                        table.AddCell(transaction.UserEmailId);
                        table.AddCell(transaction.DateOfTransaction.ToString("yyyy-MM-dd"));
                        table.AddCell(transaction.Amount.ToString("C"));
                    }

                    document.Add(table);
                }
            }

            return stream.ToArray();
        }
    }
}