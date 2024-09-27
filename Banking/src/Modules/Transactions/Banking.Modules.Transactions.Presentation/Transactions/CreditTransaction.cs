using Banking.Common.Domain;
using Banking.Common.Presentation.ApiResults;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Application.Transactions.CreditTransaction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Banking.Modules.Transactions.Presentation.Transactions;
internal sealed class CreditTransaction : IEndpoint
{
    internal sealed record Request(Guid CustomerId, decimal InitialCredit);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("v1/transactions", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new CreditTransactionCommand(
                request.CustomerId,
                request.InitialCredit));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Transactions);
    }
}
