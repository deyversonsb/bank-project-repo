using MediatR;

namespace Banking.Common.Domain;
public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
