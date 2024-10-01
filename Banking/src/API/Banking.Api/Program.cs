using Banking.Api.Configurations;
using Banking.Api.Extensions;
using Banking.Api.Middleware;
using Banking.Common.Application;
using Banking.Common.Infrastructure;
using Banking.Common.Presentation.Endpoints;
using Banking.Modules.Accounts.Infrastructure;
using Banking.Modules.Transactions.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace('+', '.'));
});

builder.Services.AddApplication([
    Banking.Modules.Transactions.Application.AssemblyReference.Assembly,
    Banking.Modules.Accounts.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure(
    [TransactionsModule.ConfigureConsumers],
    builder.Configuration.GetConnectionString("Cache")!);

builder.Configuration.AddModuleConfiguration(["transactions", "accounts"]);

builder.Services.AddTransactionsModule(builder.Configuration);
builder.Services.AddAccountsModule(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(Configuration.WebUrl)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

WebApplication app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoint();

app.UseExceptionHandler();

await app.RunAsync();
