namespace DistributedSystem.Domain.Abstractions.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool IsDelete { get; protected set; }
    }
}
