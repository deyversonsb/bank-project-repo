using Banking.Api.Extensions;
using Banking.Api.Middleware;
using Banking.Common.Application;
using Banking.Common.Infrastructure;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Transactions.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace('+', '.'));
});

builder.Services.AddApplication([Banking.Modules.Transactions.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure(
    builder.Configuration.GetConnectionString("Cache")!);

builder.Configuration.AddModuleConfiguration(["transactions"]);

builder.Services.AddTransactionsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoint();

app.UseExceptionHandler();

await app.RunAsync();
