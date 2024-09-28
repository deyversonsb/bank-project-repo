using Banking.Common.Domain;
using Banking.Common.Presentation.ApiResults;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Application.Transactions.DebitTransaction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Banking.Modules.Transactions.Presentation.Transactions;
internal sealed class DebitTransaction : IEndpoint
{
    internal sealed record Request(Guid CustomerId, decimal Amount);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("v1/transactions/debit", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new DebitTransactionCommand(request.CustomerId, request.Amount));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Transactions);
    }
}
