using System.Net;
using System.Net.Mail;

public interface IMessageClient
{
    void SendConfirmation(Guest guest, string html); 
}
public class EmailClient : IMessageClient
{
    private readonly ILogger<EmailClient> _logger;
    private readonly IConfiguration _configuration;
    private readonly string _senderEmail;
    private readonly string _senderPassword;
    private readonly string _smtpClient;

    public EmailClient(ILogger<EmailClient> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _senderEmail = _configuration["Email:Address"];
        _senderPassword = _configuration["Email:Password"];
        _smtpClient = _configuration["Email:SmtpClient"];
    }
    public void SendConfirmation(Guest guest, string html)
    {
        var smtpClient = new SmtpClient(_smtpClient)
        {
            Port = 587,
            Credentials = new NetworkCredential(_senderEmail, _senderPassword),
            EnableSsl = true,
        };
        var message = new MailMessage
        {
            From = new MailAddress(_senderEmail),
            Subject = "Wedding confirmation",
            IsBodyHtml = true,
            Body = html,
        };
        message.To.Add(guest.Email);
        smtpClient.Send(message);

        _logger.LogInformation("Sent email to: " + guest.Email);
    }
}
public class FakeEmailClient : IMessageClient
{
    private readonly ILogger<FakeEmailClient> _logger;
    public FakeEmailClient(ILogger<FakeEmailClient> logger)
    {
        _logger = logger;
    }
    public void SendConfirmation(Guest guest, string html)
    {
        _logger.LogInformation("Skipped emailing: " + guest.Email);
        File.WriteAllText(".\\index.html", html);
    }
}

