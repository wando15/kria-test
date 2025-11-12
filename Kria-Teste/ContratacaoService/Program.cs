using ContratacaoService;
using CrossCutting.DependenceInjection;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ContratacaoWorkerService>();
builder.Services.AddLogging();
var configuration = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(sp => configuration);

builder.Services.AddMongoDB(configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddCommands();

var host = builder.Build();
host.Run();
