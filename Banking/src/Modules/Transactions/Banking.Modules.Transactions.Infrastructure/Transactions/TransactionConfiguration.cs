using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Banking.Modules.Transactions.Domain.Transactions;
using Banking.Modules.Transactions.Domain.Customers;

namespace Banking.Modules.Transactions.Infrastructure.Transactions;
internal sealed class TransacationConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasOne<Customer>().WithMany().HasForeignKey(t => t.CustomerId);
    }
}

