using Banking.Common.Domain;
using Banking.Modules.Accounts.Domain.Customers;
using Banking.Modules.Accounts.UnitTests.Abstractions;
using FluentAssertions;

namespace Banking.Modules.Accounts.UnitTests.Customers;
public class CustomerTests : BaseTest
{
    [Fact]
    public void Create_ShouldReturnFailure_WhenInitalCreditLessThanZero()
    {
        // Arrange
        decimal initialCredit = -10;


        // Act
        Result<Customer> result = Customer.Create(
            Faker.Name.FirstName(),
            Faker.Name.LastName(),
            initialCredit);


        // Assert
        result.Error.Should().Be(CustomerErrors.InitialCreditLessThanZero);
    }

    [Fact]
    public void Create_ShouldRaiseDomainEvent_WhenCustomerCreated()
    {
        // Arrange
        decimal initialCredit = 10;


        // Act
        Result<Customer> result = Customer.Create(
            Faker.Name.FirstName(),
            Faker.Name.LastName(),
            initialCredit);

        Customer customer = result.Value;

        // Assert
        CustomerCreatedDomainEvent domainEvent = AssertDomainEventWasPublished<CustomerCreatedDomainEvent>(customer);

        domainEvent.CustomerId.Should().Be(customer.Id);
    }
}
