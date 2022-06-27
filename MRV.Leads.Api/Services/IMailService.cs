using SendGrid;
using SendGrid.Helpers.Mail;

namespace MRV.Leads.Api.Services;

public interface IMailService
{
    Task SendEmailAsync(string toEmail, string subject, string content);
}

public class SendgrindMailService : IMailService
{
    private IConfiguration _configuration;

    public SendgrindMailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var apiKey = _configuration["SendGridAPIKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("guilherme.julio@iebtdigital.com.br", "Leads Platform");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        await client.SendEmailAsync(msg);
    }
}