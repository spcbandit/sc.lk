namespace SC.LK.Application.Domains.Entities
{
    public class KeysEntity : BaseEntity
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
}