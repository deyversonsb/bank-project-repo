using Banking.Common.Domain;
using Banking.Common.Presentation.ApiResults;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Accounts.Application.Customers.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Banking.Modules.Accounts.Presentation.Customers;
internal sealed class CreateCustomer : IEndpoint
{
    internal sealed record Request(string Name, string Surname, decimal InitialCredit);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("v1/accounts", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new CreateCustomerCommand(
                request.Name,
                request.Surname,
                request.InitialCredit));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Accounts);
    }
}
