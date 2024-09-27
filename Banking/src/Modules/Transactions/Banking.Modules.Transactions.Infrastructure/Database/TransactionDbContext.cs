using Banking.Modules.Transactions.Application.Abstractions.Data;
using Banking.Modules.Transactions.Domain.Customers;
using Banking.Modules.Transactions.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Modules.Transactions.Infrastructure;
public sealed class TransactionDbContext(
    DbContextOptions<TransactionDbContext> options) : DbContext(options), IUnitOfWork   
{
    internal DbSet<Transaction> Transactions { get; set; }
    internal DbSet<Customer> Customers { get; set; }
}
