namespace BankingApplication.Application.Services.Email;

public interface IEmailService
{
    void SendEmail(string toEmail, byte[] pdfContent, string fileName);
}