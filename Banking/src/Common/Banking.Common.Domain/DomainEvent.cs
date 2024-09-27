namespace Banking.Common.Domain;
public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOnUtc = DateTime.UtcNow;
    }
    protected DomainEvent(Guid id, DateTime occcurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occcurredOnUtc;
    }
    public Guid Id { get; init; }
    public DateTime OccurredOnUtc { get; init; }
}
