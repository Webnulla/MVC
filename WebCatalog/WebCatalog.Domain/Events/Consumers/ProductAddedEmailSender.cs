using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebCatalog.Domain.EmailSender;

namespace WebCatalog.Domain.Events.Consumers;

public class ProductAddedEmailSender : BackgroundService
{
    private readonly IEmailSender _emailService;
    private readonly ILogger<ProductAddedEmailSender> _logger;

    public ProductAddedEmailSender(IEmailSender emailService, ILogger<ProductAddedEmailSender> logger)
    {
        _emailService = emailService;
        _logger = logger;
        DomainEvents.Register<ProductAddedSubmitted>(e => _ = SendEmailNotification(e));
    }

    private async Task SendEmailNotification(ProductAddedSubmitted productAddedSubmitted)
    {
        try
        {
            await _emailService.SendEmail("muselsps@ya.ru", "Продукт добавлен", "Добавление продукта");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Ошибка отправки имейла");
        }
        
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }
}