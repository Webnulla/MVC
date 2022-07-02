namespace WebCatalog.Domain.EmailSender;

public interface IEmailSender
{
    Task SendEmail(string email, string subject, string message);
}