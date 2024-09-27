using Banking.Common.Application.Caching;
using Banking.Common.Domain;
using Banking.Common.Presentation.ApiResults;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Application.Transactions.GetTransaction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Banking.Modules.Transactions.Presentation.Transactions;
internal sealed class GetTransaction : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("v1/transactions/{id}", async (Guid id, ISender sender, ICacheService cacheService) =>
        {
            TransactionResponse transactionResponse =
                await cacheService.GetAsync<TransactionResponse>($"transaction_by_id_{id}");

            if (transactionResponse is not null)
            {
                Results.Ok(transactionResponse);
            }

            Result<TransactionResponse> result = await sender.Send(new GetTransactionQuery(id));

            if (result.IsSuccess)
            {
                await cacheService.SetAsync<TransactionResponse>($"transaction_by_id_{id}", result.Value);
            }

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Transactions);
    }
}
