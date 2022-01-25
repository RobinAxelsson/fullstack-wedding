using System.Net;
using System.Net.Mail;

public interface IEmailClient
{
    void SendConfirmation(Guest guest);
}
public class EmailClient : IEmailClient
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
    public void SendConfirmation(Guest guest)
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
            Body = "<h1>Hello World</h1>"
        };
        message.To.Add(guest.Email);
        smtpClient.Send(message);

        _logger.LogInformation("Sent email to: " + guest.Email);
    }
}
public class FakeEmailClient : IEmailClient
{
    private readonly ILogger<FakeEmailClient> logger;
    public FakeEmailClient(ILogger<FakeEmailClient> logger)
    {
        this.logger = logger;
    }
    public void SendConfirmation(Guest guest)
    {
        logger.LogInformation("Skipped emailing: " + guest.Email);
    }
}

