namespace Bootcamp.Domain
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
        public DateTime? InsertedAt { get; set; }
        public int? InsertedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
