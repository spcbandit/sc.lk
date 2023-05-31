using SC.LK.Application.Abstractions.MailSender;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SC.LK.Application.Domains.MailSender;

namespace SC.LK.Infrastructure.MailSender.Adaptors;

public class MailKitAdaptor : IMailKit
{
    private MimeMessage _emailMessage;
    private MailKitOptions _mailKitOptions;
    private AdminMailKitOptions _adminMailKit;
    
    /// <summary>
    /// Конструктор отправки письма
    /// </summary>
    /// <param name="options"></param>
    public MailKitAdaptor(IOptions<MailKitOptions> options,IOptions<AdminMailKitOptions> adminMailKit)
    {
        _mailKitOptions = options.Value;
        _emailMessage = new MimeMessage();
        _adminMailKit = adminMailKit.Value;
    }
    
    /// <summary>
    /// Отправка письма
    /// </summary>
    /// <param name="to"></param>
    /// <param name="message"></param>
    public async Task SendMessage(string to, string message)
    {
        _emailMessage.From.Add(new MailboxAddress(_mailKitOptions.Name, _mailKitOptions.Mail));
        _emailMessage.To.Add(new MailboxAddress("", to));
        _emailMessage.Subject = _mailKitOptions.Subject;
        _emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = CreateLatter(_mailKitOptions.Subject, message)
        };
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_mailKitOptions.MailType, _mailKitOptions.Port, true);
            await client.AuthenticateAsync(_mailKitOptions.Mail, _mailKitOptions.Password);
            await client.SendAsync(_emailMessage);
            await client.DisconnectAsync(true);
        }

    }

    public async Task NotifyAdmin(string to, string message)
    {
        _emailMessage.From.Add(new MailboxAddress(_adminMailKit.Name, _adminMailKit.Mail));
        _emailMessage.To.Add(new MailboxAddress("Admin", _adminMailKit.Recipient));
        _emailMessage.Subject = _adminMailKit.Subject;
        _emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = message
        };
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_adminMailKit.MailType, _adminMailKit.Port, true);
            await client.AuthenticateAsync(_adminMailKit.Mail, _adminMailKit.Password);
            await client.SendAsync(_emailMessage);
            await client.DisconnectAsync(true);
        }
    }

    /// <summary>
    /// Создание письма
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    private string CreateLatter(string subject, string content)
    {
        string letter = String.Format(
            $"<p>Ваш код активации аккаунта Enterprise: {content}</p>");
        return letter;
    }
}