using ContratacaoService;
using CrossCutting.DependenceInjection;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ContratacaoWorkerService>();
builder.Services.AddLogging();
var configuration = builder.Configuration;

builder.Services.AddMongoDB(configuration);
builder.Services.AddRepositories();
builder.Services.AddCommands();
builder.Services.AddServices();

var host = builder.Build();
host.Run();
