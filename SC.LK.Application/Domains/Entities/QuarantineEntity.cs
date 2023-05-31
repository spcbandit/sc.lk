namespace SC.LK.Application.Domains.Entities
{
    public class QuarantineEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Хранит ID контрагента
        public Guid QuarantineMemberId { get; set; }
        // Хранит дату добавления в карантин
        public DateTime DateQuarantineAdd { get; set; }
        public bool Deleted { get; set; }
    }
}