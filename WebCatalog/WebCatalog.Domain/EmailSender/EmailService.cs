using MailKit.Net.Smtp;
using MimeKit;

namespace WebCatalog.Domain.EmailSender;

public class EmailService
{
    public async Task SendEmail(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Тест", "muselsps@ya.ru"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.beget.com", 25, false);
            await client.AuthenticateAsync("asp***********on-m.ru", "3******1");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}