using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Modules.Transactions.Domain.Transactions;

namespace Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
public sealed record TransactionResponse(
    Guid Id,
    decimal Amount,
    TransactionType TransactionType,
    string TransactionName,
    DateTime CreatedAtUtc);
