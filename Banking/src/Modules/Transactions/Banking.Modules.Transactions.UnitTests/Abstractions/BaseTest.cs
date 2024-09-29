using Banking.Common.Domain;

namespace Banking.Modules.Transactions.UnitTests.Abstractions;

public abstract class BaseTest
{
    public static T AssertDomainEventWasPublished<T>(Entity entity)
        where T : IDomainEvent
    {
        T? domainEvent = entity.DomainEvents.OfType<T>().SingleOrDefault();

        if (domainEvent is null)
        {
            throw new Exception($"{typeof(T).Name} was not published.");
        }

        return domainEvent;
    }
}
