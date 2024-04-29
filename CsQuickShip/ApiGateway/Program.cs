using ApiGateway;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(builder.Configuration);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.ApiGatewayDependency(builder.Configuration);

var app = builder.Build();

app.UseCors("MyPolicy");
await app.UseOcelot();
app.Run();
