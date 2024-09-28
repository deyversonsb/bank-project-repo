using Banking.Common.Application.EventBus;

namespace Banking.Modules.Accounts.IntegrationEvents;

public sealed class CustomerCreatedIntegrationEvent : IntegrationEvent
{
    public CustomerCreatedIntegrationEvent(
        Guid id,
        DateTime occurredOnUtc,
        Guid customerId,
        string name,
        string surname,
        DateTime createdAtUtc,
        decimal initialCredit)
        : base(id, occurredOnUtc)
    {
        CustomerId = customerId;
        Name = name;
        Surname = surname;
        CreatedAtUtc = createdAtUtc;
        InitialCredit = initialCredit;
    }
    public Guid CustomerId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public DateTime CreatedAtUtc { get; init; }
    public decimal InitialCredit { get; init; }
}
