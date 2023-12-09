using System.Net;
using System.Net.Mail;

namespace BankingApplication.Application.Services.Email;

public class EmailService : IEmailService
{
    public void SendEmail(string toEmail, byte[] pdfContent, string fileName)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("malicicek1@gmail.com", "nvus lbhi lghn osyi"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage("malicicek1@gmail.com", "malicicek1@gmail.com")
        {
            Subject = "Transaction Report",
            Body = "Please find your transaction report attached."
        };

        var attachment = new Attachment(new MemoryStream(pdfContent), fileName);
        mailMessage.Attachments.Add(attachment);

        smtpClient.Send(mailMessage);

        Console.WriteLine($"Email sent to {toEmail} with PDF attachment.");
    }
}