using MassTransit;
using MediatR;


namespace DistributedSystem.Contract.Abstractions.Message
{
    [ExcludeFromTopology]
    public interface IDomainEvent //: INotification
    {
        public Guid IdEvent { get; init; }
    }
}
