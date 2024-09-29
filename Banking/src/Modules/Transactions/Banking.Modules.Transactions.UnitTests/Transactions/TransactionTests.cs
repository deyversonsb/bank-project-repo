using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Common.Domain;
using Banking.Modules.Transactions.Domain.Transactions;
using Banking.Modules.Transactions.UnitTests.Abstractions;
using FluentAssertions;

namespace Banking.Modules.Transactions.UnitTests.Transactions;
public class TransactionTests : BaseTest
{
    [Fact]
    public void Create_ShouldReturnFailure_WhenAmountLessThanOrEqualZero()
    {
        //Arrange
        var customerId = Guid.NewGuid();

        //Act
        Result<Transaction> result = Transaction.Create(customerId, 0);

        //Assert
        result.Error.Should().Be(TransactionErrors.AmountLessThanOrEqualZero);
    }

    [Fact]
    public void Create_ShouldRaiseDomainEvent_WhenTransactionCreated()
    {
        //Arrange
        var customerId = Guid.NewGuid();

        //Act
        Result<Transaction> result = Transaction.Create(customerId, 10);

        Transaction transaction = result.Value;

        //Assert
        TransactionCreatedDomainEvent domainEvent = AssertDomainEventWasPublished<TransactionCreatedDomainEvent>(transaction);

        domainEvent.TransactionId.Should().Be(transaction.Id);
    }

    [Fact]
    public void Credit_ShouldReturnFailure_WhenAmoutLessThanOrEqualZero()
    {
        //Arrange
        var customerId = Guid.NewGuid();
        decimal amount = -10;

        //Act
        Result<Transaction> transactionResult = Transaction.Create(customerId);

        Transaction transaction = transactionResult.Value;

        Result result = transaction.Credit(amount);

        //Assert
        result.Error.Should().Be(TransactionErrors.AmountLessThanOrEqualZero);
    }

    [Fact]
    public void Credit_ShouldRaiseDomainEvent_WhenAmountCredited()
    {
        //Arrange
        var customerId = Guid.NewGuid();
        decimal amount = 10;

        //Act
        Result<Transaction> result = Transaction.Create(customerId);

        Transaction transaction = result.Value;

        transaction.Credit(amount);

        //Assert
        TransactionCreditedDomainEvent domainEvent = AssertDomainEventWasPublished<TransactionCreditedDomainEvent>(transaction);

        domainEvent.TransactionId.Should().Be(transaction.Id);
        domainEvent.CustomerId.Should().Be(transaction.CustomerId);
        domainEvent.Amount.Should().Be(transaction.Amount);
        domainEvent.CreatedAtUtc.Should().Be(transaction.CreatedAtUtc);
    }

    [Fact]
    public void Debit_ShouldReturnFailure_WhenAmountLessThanOrEqualZero()
    {
        //Arrange
        var customerId = Guid.NewGuid();
        decimal amount = -10;

        //Act
        Result<Transaction> transactionResult = Transaction.Create(customerId);

        Transaction transaction = transactionResult.Value;

        Result result = transaction.Debit(amount);

        //Assert
        result.Error.Should().Be(TransactionErrors.AmountLessThanOrEqualZero);
    }

    [Fact]
    public void Debit_ShouldRaiseDomainEvent_WhenAmoutDebited()
    {
        //Arrange
        var customerId = Guid.NewGuid();
        decimal amount = 10;

        //Act
        Result<Transaction> result = Transaction.Create(customerId);

        Transaction transaction = result.Value;

        transaction.Debit(amount);

        //Assert
        TransactionDebitedDomainEvent domainEvent = AssertDomainEventWasPublished<TransactionDebitedDomainEvent>(transaction);

        domainEvent.TransactionId.Should().Be(transaction.Id);
        domainEvent.CustomerId.Should().Be(transaction.CustomerId);
        domainEvent.Amount.Should().Be(transaction.Amount);
        domainEvent.CreatedAtUtc.Should().Be(transaction.CreatedAtUtc);
    }
}
