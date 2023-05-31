namespace SC.LK.Application.Abstractions.MailSender;

public interface IMailKit
{
    Task SendMessage(string to, string massage);
    Task NotifyAdmin(string to, string message);
}