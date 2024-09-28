using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Common.Domain;
using Banking.Common.Presentation.ApiResults;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Application.Transactions.GetTransactionsByCustomer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Banking.Modules.Transactions.Presentation.Transactions;
public sealed class GetTransactionsByCustomer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("v1/transactions/customers/{id}", async (Guid id, ISender sender) =>
        {
            Result<CustomerTransactionReponse> result = await sender.Send(
                new GetTransactionsByCustomerQuery(id));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Transactions);
    }
}
