using Banking.Modules.Accounts.Application.Abstractions;
using Banking.Modules.Accounts.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Banking.Modules.Accounts.Infrastructure.Database;

public sealed class AccountsDbContext(
    DbContextOptions<AccountsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Customer> Customers { get; set; }
}
