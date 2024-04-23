using Label.Application;
using Label.Infrastructure;
using Label.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db
builder.Services.AddDbContext(builder.Configuration);
//Add mediatr
builder.Services.AddMediatr(builder.Configuration);
//Add dependencies from infra layer
builder.Services.AddInfratructureDependencies(builder.Configuration);
//Add fedexcredentials
var section = builder.Configuration.GetSection("FedexCredentials");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
