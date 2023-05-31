namespace SC.LK.Application.Domains.MailSender;

public class AdminMailKitOptions
{
    /// <summary>
    /// Тема письма
    /// </summary>
    public string Subject { get; set; }
    
    /// <summary>
    /// Имя отправителя
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Мыло отправителя
    /// </summary>
    public string Mail { get; set; }
    
    /// <summary>
    /// Пароль от почты отправителя
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Тип письма
    /// </summary>
    public string MailType { get; set; }
    
    /// <summary>
    /// Получатель
    /// </summary>
    public string Recipient { get; set; }
    
    /// <summary>
    /// Port
    /// </summary>
    public int Port { get; set; }
}