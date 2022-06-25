using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace WebCatalog.Domain.EmailSender;

public class EmailService
{
    public async Task SendEmail(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Тест", "a********u"));
        emailMessage.To.Add(new MailboxAddress("", "muselsps@ya.ru"));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };

        var client = new SmtpClient();
        
            await client.ConnectAsync("smtp.beget.com", 25, false);
            await client.AuthenticateAsync("a**********u", "3*******1");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
    }
}