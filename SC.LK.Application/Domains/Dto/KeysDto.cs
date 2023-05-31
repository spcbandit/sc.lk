namespace SC.LK.Application.Domains.Dto;

public class KeysDto: Domains.BaseDto
{
    /// <summary>
    /// Публичный ключ
    /// </summary>
    public string? PublicKey { get; set; }

    /// <summary>
    /// Приватный ключ
    /// </summary>
    public string? PrivateKey { get; set; }

}